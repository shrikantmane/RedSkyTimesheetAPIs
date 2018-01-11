using ESPL.ERRORLOGGER;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;

namespace ESPL.AUTHENTICATION.OWINTOKEN.Models
{
    public class AuthorizeUser
    {
        public static int GetUserIDFromSPSite(string userName, string FullyQualifiedDomain, string siteUrl)
        {
            int userID = 0;
            try
            {
                //REST Url of User Information List of given site
                string RestUrl = string.Concat(siteUrl, "/_api/web/SiteUserInfoList/items?$select*&$filter=Name eq '", 
                                                System.Web.HttpUtility.UrlEncode(FullyQualifiedDomain + userName), "'");
                HttpWebRequest endpointRequest = (HttpWebRequest)HttpWebRequest.Create(RestUrl);
                endpointRequest.Method = "GET";
                endpointRequest.Accept = "application/json;odata=verbose";
                endpointRequest.ContentType = "application/json; charset=utf-8";
                endpointRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
                HttpWebResponse endpointResponse = (HttpWebResponse)endpointRequest.GetResponse();
                WebResponse webResponse = endpointRequest.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();
                JObject jobj = JObject.Parse(response);
                JArray jarr = (JArray)jobj["d"]["results"];
                if (jarr.Count > 0)
                {
                    userID = Convert.ToInt32(jarr.Select(item => Convert.ToInt64(item["Id"])).FirstOrDefault());
                }
                return userID;
            }
            catch (Exception ex)
            {
                ErrorLogger errorLogger = new ErrorLogger();
                string guid = Convert.ToString(Guid.NewGuid());
                errorLogger.Log(ex.Message, ex.StackTrace, userName, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name, Convert.ToString(ex.InnerException), guid);
                throw new Exception(string.Format("An error occured while reading data. GUID: {0}", guid));
            }
        }

    }
}