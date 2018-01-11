using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ESPL.RedSkyTimeSheet.BL;
using ESPL.RedSkyTimeSheet.BL.Models;
using Microsoft.Owin.Security.Infrastructure;
using System.Collections.Concurrent;
using Microsoft.Owin.Security;

[assembly: OwinStartup(typeof(ESPL.RedSkyTimeSheet.Startup))]
namespace ESPL.RedSkyTimeSheet
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            HttpConfiguration config = new HttpConfiguration();
            ConfigureOAuth(app);
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new PrincipalContext(ContextType.Domain));

            string time = "1440";
            double tokentime = 1440;
            Double.TryParse(time, out tokentime);
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,

                TokenEndpointPath = new PathString("/api/Auth/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(tokentime),

                Provider = new AuthorizationServerProvider(),
                RefreshTokenProvider = new RefreshTokenProvider()

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
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, ESPL.RedSkyTimeSheet.Models.Constants.DomainName))
                {
                    //Validate user credentials with AD
                    if (pc.ValidateCredentials(context.UserName, context.Password))
                    {

                        //Get User ID of given user from the site if the user is authorized to access site
                        UserInformation userInfo = UserInfoOperations.GetUserInfo(context.UserName, ESPL.RedSkyTimeSheet.Models.Constants.QualifiedDomainName,
                                                                                        ESPL.RedSkyTimeSheet.Models.Constants.SiteUrl);
                        //check authorization id. If user id is zero "0" then the given user is not authorized to access the site
                        if (userInfo.ID == 0)
                        {
                            context.SetError("unauthorized_user", "User is not authorized to site");
                            return;
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
                            identity.AddClaim(new Claim("Email", ""));
                        else
                            identity.AddClaim(new Claim("Email", Convert.ToString(UserInfoFromAD.EmailAddress)));
                        if (UserInfoFromAD.VoiceTelephoneNumber == null)
                            identity.AddClaim(new Claim("Telephone", ""));
                        else
                            identity.AddClaim(new Claim("Telephone", Convert.ToString(UserInfoFromAD.VoiceTelephoneNumber)));                       
                        if (userInfo.ID == 0)
                            identity.AddClaim(new Claim("UserID", ""));
                        else
                            identity.AddClaim(new Claim("UserID", Convert.ToString(userInfo.ID)));
                        identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                        context.Validated(identity);

                    }
                    else
                    {
                        context.SetError("inactive_user", "Invalid User Name or Password");
                        return;
                    }
                }
            }

            public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
            {
                
                // Change authentication ticket for refresh token requests
                var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
                newIdentity.AddClaim(new Claim("newClaim", "newValue"));

                var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
                context.Validated(newTicket);

                return Task.FromResult<object>(null);
            }

            public override Task TokenEndpoint(OAuthTokenEndpointContext context)
            {
                foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
                {
                    context.AdditionalResponseParameters.Add(property.Key.Trim('.'), property.Value);
                }

                return Task.FromResult<object>(null);
            }
        }

        public class RefreshTokenProvider : IAuthenticationTokenProvider
        {
            private static ConcurrentDictionary<string, AuthenticationTicket> _refreshTokens = new ConcurrentDictionary<string, AuthenticationTicket>();

            public async Task CreateAsync(AuthenticationTokenCreateContext context)
            {
                var guid = Guid.NewGuid().ToString();

                // copy properties and set the desired lifetime of refresh token
                var refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
                {
                    IssuedUtc = context.Ticket.Properties.IssuedUtc,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(60)//DateTime.UtcNow.AddYears(1)
                };
                var refreshTokenTicket = new AuthenticationTicket(context.Ticket.Identity, refreshTokenProperties);

                _refreshTokens.TryAdd(guid, refreshTokenTicket);

                // consider storing only the hash of the handle
                context.SetToken(guid);
            }

            public void Create(AuthenticationTokenCreateContext context)
            {
                throw new NotImplementedException();
            }

            public void Receive(AuthenticationTokenReceiveContext context)
            {
                throw new NotImplementedException();
            }

            public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
            {
                AuthenticationTicket ticket;
                string header = context.OwinContext.Request.Headers["Authorization"];

                if (_refreshTokens.TryRemove(context.Token, out ticket))
                {
                    context.SetTicket(ticket);
                }
            }
        }
    }
}