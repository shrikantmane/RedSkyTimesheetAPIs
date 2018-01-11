using ESPL.RedSkyTimeSheet.Lists;
using ESPL.SHAREPOINT.RESTSERVICE;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Configuration;

namespace ESPL.RedSkyTimeSheet.DAL
{
    public class CRUDOperations
    {
        public static List<T> GetListByRestURL<T>(string RestUrl)
        {
            string accessToken = (HttpContext.Current.Request.Headers["Authorization"]).Split(' ')[1];
            List<T> lst = new List<T>();
            try
            {
                JObject jobj = RestAPI.GetResponseFromEndPointRequest(RestUrl, System.Net.CredentialCache.DefaultCredentials);
                JArray jarr = (JArray)jobj["d"]["results"];
                if (jarr.Count > 0)
                {
                    lst = jarr.ToObject<List<T>>();
                }
                return lst;
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public static Result AddListItem(string listName, string itemPostBody)
        {
            string DomainName = Convert.ToString(WebConfigurationManager.AppSettings["DomainName"]);
            string SiteUrl = Convert.ToString(WebConfigurationManager.AppSettings["SiteUrl"]);
            string accessToken = (HttpContext.Current.Request.Headers["Authorization"]).Split(' ')[1];
            string errorLogPath = Convert.ToString(WebConfigurationManager.AppSettings["ErrorLogPath"]);
            Result res = new Result();
            try
            {
                RestAPI.AddListItems(SiteUrl, errorLogPath, accessToken, Lists.ListURLs.RestUrlList(listName),
                                       Lists.ListURLs.RestUrlListItemWithQuery(listName, false), itemPostBody, Convert.ToString(GetUserInfo.UserID));

                res.StatusCode = StatusCode.Success;
                res.Message = Messages.MsgSuccessAdd;

                return res;
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));

            }
        }

        public static Result AddListItem<T>(string listName, T obj)
        {
            string id = string.Empty;
            string itemPostBody = GenerateJsonFromObject.GenerateJson<T>(obj, out id);

            string DomainName = Convert.ToString(WebConfigurationManager.AppSettings["DomainName"]);
            string SiteUrl = Convert.ToString(WebConfigurationManager.AppSettings["SiteUrl"]);
            string accessToken = (HttpContext.Current.Request.Headers["Authorization"]).Split(' ')[1];
            string errorLogPath = Convert.ToString(WebConfigurationManager.AppSettings["ErrorLogPath"]);
            Result res = new Result();
            try
            {
                RestAPI.AddListItems(SiteUrl, errorLogPath, accessToken, Lists.ListURLs.RestUrlList(listName),
                                       Lists.ListURLs.RestUrlListItemWithQuery(listName, false), itemPostBody, Convert.ToString(GetUserInfo.UserID));

                res.StatusCode = StatusCode.Success;
                res.Message = Messages.MsgSuccessAdd;

                return res;
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));

            }
        }

        public static Result UpdateListItem(string listName, string itemPostBody, string id)
        {
            string SiteUrl = Convert.ToString(WebConfigurationManager.AppSettings["SiteUrl"]);
            string accessToken = (HttpContext.Current.Request.Headers["Authorization"]).Split(' ')[1];
            string errorLogPath = Convert.ToString(WebConfigurationManager.AppSettings["ErrorLogPath"]);
            Result res = new Result();
            try
            {
                RestAPI.UpdateListItems(SiteUrl, errorLogPath, accessToken, Lists.ListURLs.RestUrlList(listName),
                                        Lists.ListURLs.RestUrlListItemWithQuery(listName, false), itemPostBody, id, Convert.ToString(GetUserInfo.UserID));

                res.StatusCode = StatusCode.Success;
                res.Message = Messages.MsgSuccessUpdate;

                return res;
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));

            }
        }

        public static Result UpdateListItem<T>(string listName,T obj)
        {
            string id = string.Empty;
            string itemPostBody = GenerateJsonFromObject.GenerateJson<T>(obj, out id);
            string SiteUrl = Convert.ToString(WebConfigurationManager.AppSettings["SiteUrl"]);
            string accessToken = (HttpContext.Current.Request.Headers["Authorization"]).Split(' ')[1];
            string errorLogPath = Convert.ToString(WebConfigurationManager.AppSettings["ErrorLogPath"]);
            Result res = new Result();
            try
            {
                RestAPI.UpdateListItems(SiteUrl, errorLogPath, accessToken, Lists.ListURLs.RestUrlList(listName),
                                        Lists.ListURLs.RestUrlListItemWithQuery(listName, false), itemPostBody, id, Convert.ToString(GetUserInfo.UserID));

                res.StatusCode = StatusCode.Success;
                res.Message = Messages.MsgSuccessUpdate;

                return res;
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));

            }
        }

        public static Result DeleteListItem(string listName, string id)
        {
            string SiteUrl = Convert.ToString(WebConfigurationManager.AppSettings["SiteUrl"]);
            string accessToken = (HttpContext.Current.Request.Headers["Authorization"]).Split(' ')[1];
            string errorLogPath = Convert.ToString(WebConfigurationManager.AppSettings["ErrorLogPath"]);
            Result res = new Result();
            try
            {
                RestAPI.DeleteListItems(SiteUrl, errorLogPath, accessToken, Lists.ListURLs.RestUrlList(listName),
                                        Lists.ListURLs.RestUrlListItemWithQuery(listName, false), id);

                res.StatusCode = StatusCode.Success;
                res.Message = Messages.MsgSuccessDelete;

                return res;
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));

            }
        }
    }
}
