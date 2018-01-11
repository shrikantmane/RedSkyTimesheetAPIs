using ESPL.RedSkyTimeSheet.DAL;
using ESPL.RedSkyTimeSheet.Lists;
using ESPL.SHAREPOINT.RESTSERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESPL.RedSkyTimeSheet.BL.Operations.Masters
{
    public class EngagementOperations
    {
        public List<Engagements> Engagements(string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Engagements, true));

                return CRUDOperations.GetListByRestURL<Engagements>(RestUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public Engagements EngagementByID(string id, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Engagements, true),
                                                    string.Format(Lists.RestFilters.ByID, id));

                return CRUDOperations.GetListByRestURL<Engagements>(RestUrl).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public Engagements EngagementByName(string name, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Engagements, true),
                                                    string.Format(Lists.RestFilters.ByTitle, name));

                return CRUDOperations.GetListByRestURL<Engagements>(RestUrl).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public List<Engagements> EngagementsByProjectID(string projectID, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Engagements, true),
                                                    string.Format(Lists.RestFilters.ByProjectID, projectID),
                                                    string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<Engagements>(RestUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public List<Engagements> EngagementsByProjectName(string projectName, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Engagements, true),
                                                    string.Format(Lists.RestFilters.ByProjectName, projectName),
                                                    string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<Engagements>(RestUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public Result AddEngagement(Engagements objEngagement, string siteUrl)
        {
            Result res = new Result();
            try
            {
                res = CRUDOperations.AddListItem<Engagements>(Lists.Lists.Engagements, objEngagement);

                res.StatusCode = StatusCode.Success;
                res.Message = Messages.MsgSuccessAdd;
                return res;
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                res.Message = Messages.MsgSomethingWentWrong;
                res.StatusCode = StatusCode.Error;
                return res;
            }
        }

        public Result UpdateEngagement(Engagements objEngagement, string siteUrl)
        {
            Result res = new Result();
            try
            {
                res = CRUDOperations.UpdateListItem<Engagements>(Lists.Lists.Engagements, objEngagement);

                res.StatusCode = StatusCode.Success;
                res.Message = Messages.MsgSuccessUpdate;
                return res;
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                res.Message = Messages.MsgSomethingWentWrong;
                res.StatusCode = StatusCode.Error;
                return res;
            }
        }

    }
}
