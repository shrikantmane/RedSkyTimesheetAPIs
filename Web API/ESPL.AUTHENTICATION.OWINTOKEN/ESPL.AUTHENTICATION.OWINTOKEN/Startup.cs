using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.DirectoryServices.AccountManagement;
using ESPL.AUTHENTICATION.OWINTOKEN.Models;

[assembly: OwinStartup(typeof(ESPL.AUTHENTICATION.OWINTOKEN.Startup))]
namespace ESPL.AUTHENTICATION.OWINTOKEN
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            // This is the important part, this is how you will configure the PrincipalContext used throughout your app
            app.CreatePerOwinContext(() => new PrincipalContext(ContextType.Domain));

            string time = "1440";
            double tokentime = 1440;
            Double.TryParse(time, out tokentime);
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/api/Authentication/GetToken"),
                Provider = new AuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(tokentime),
                AllowInsecureHttp = true,


            });
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                AuthenticationType = "Bearer"
            });
            app.UseCors(CorsOptions.AllowAll);
        }

        public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
        {
            public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                context.Validated();
            }
            public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {

                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, ESPL.AUTHENTICATION.OWINTOKEN.Models.Constants.DomainName))
                {
                    //Validate user credentials with AD
                    if (pc.ValidateCredentials(context.UserName, context.Password))
                    {
                        int authorizedUserID = 0;
                        //Authorize user if site url is provided in Scope of context 
                        if (context.Scope != null && !string.IsNullOrEmpty(context.Scope[0]))
                        {
                            //Get User ID of given user from the site if the user is authorized to access site
                            authorizedUserID = AuthorizeUser.GetUserIDFromSPSite(context.UserName, ESPL.AUTHENTICATION.OWINTOKEN.Models.Constants.QualifiedDomainName,
                                                                                        context.Scope[0]);
                            //check authorization id. If user id is zero "0" then the given user is not authorized to access the site
                            if (authorizedUserID == 0)
                            {
                                context.SetError("unauthorized_user", "User is not authorized to access site");
                                return;
                            }
                        }

                        //Get user information from AD
                        UserPrincipal UserInfoFromAD = UserPrincipal.FindByIdentity(pc, context.UserName.ToString());

                        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                        identity.AddClaim(new Claim("LoginName", Convert.ToString(context.UserName)));
                        if (UserInfoFromAD.GivenName == null)
                            identity.AddClaim(new Claim("FirstName", ""));
                        else
                            identity.AddClaim(new Claim("FirstName", Convert.ToString(UserInfoFromAD.GivenName)));
                        if (UserInfoFromAD.MiddleName == null)
                            identity.AddClaim(new Claim("MiddleName", ""));
                        else
                            identity.AddClaim(new Claim("MiddleName", Convert.ToString(UserInfoFromAD.MiddleName)));
                        if (UserInfoFromAD.Surname == null)
                            identity.AddClaim(new Claim("LastName", ""));
                        else
                            identity.AddClaim(new Claim("LastName", Convert.ToString(UserInfoFromAD.Surname)));
                        if (UserInfoFromAD.EmailAddress == null)
                            identity.AddClaim(new Claim("EmailAddress", ""));
                        else
                            identity.AddClaim(new Claim("EmailAddress", Convert.ToString(UserInfoFromAD.EmailAddress)));
                        if (UserInfoFromAD.VoiceTelephoneNumber == null)
                            identity.AddClaim(new Claim("Telephone", ""));
                        else
                            identity.AddClaim(new Claim("Telephone", Convert.ToString(UserInfoFromAD.VoiceTelephoneNumber)));
                        if (UserInfoFromAD.EmployeeId == null)
                            identity.AddClaim(new Claim("EmployeeID", ""));
                        else
                            identity.AddClaim(new Claim("EmployeeID", Convert.ToString(UserInfoFromAD.EmployeeId)));
                        identity.AddClaim(new Claim("UserName", Convert.ToString(UserInfoFromAD.Name)));
                        if (authorizedUserID == 0)
                            identity.AddClaim(new Claim("UserID", ""));
                        else
                            identity.AddClaim(new Claim("UserID", Convert.ToString(authorizedUserID)));
                        identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                        context.Validated(identity);

                    }
                    else
                    {
                        context.SetError("inactive_user", "User is not valid custom message");
                        return;
                    }
                }
            }
        }

    }
}