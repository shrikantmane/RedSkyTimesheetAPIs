using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;
using ESPL.SHAREPOINT.RESTSERVICE;

namespace ESPL.RedSkyTimeSheet.BL.Models
{
    public static class UserInfoOperations
    {
        public static UserInformation GetUserInfo(string userName, string FullyQualifiedDomain, string siteUrl)
        {
            string RestUrl = string.Concat(siteUrl, "/_api/web/SiteUserInfoList/items", "?$select*&$filter=Name eq '", 
                                                System.Web.HttpUtility.UrlEncode(FullyQualifiedDomain + userName), "'");

            UserInformation objUserInfo = new UserInformation();
            try
            {

                JObject jobj = RestAPI.GetResponseFromEndPointRequest(RestUrl, System.Net.CredentialCache.DefaultCredentials);
                JArray jarr = (JArray)jobj["d"]["results"];
                if (jarr.Count > 0)
                {
                    objUserInfo.ID = Convert.ToInt32(jarr.Select(item => Convert.ToInt64(item["Id"])).FirstOrDefault());
                    objUserInfo.EmailId = jarr.Select(item => Convert.ToString(item["EMail"])).FirstOrDefault();
                }
                return objUserInfo;

            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occured while reading data. GUID: {0}", guid));
            }
        }
    }
}
