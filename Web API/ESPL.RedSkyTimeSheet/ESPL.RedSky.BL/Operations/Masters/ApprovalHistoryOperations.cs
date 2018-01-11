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
    public class ApprovalHistoryOperations
    {
        public List<ApprovalHistory> GetApprovalHistory(string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.ApprovalHistory, true));

                return CRUDOperations.GetListByRestURL<ApprovalHistory>(RestUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public ApprovalHistory GetApprovalHistoryByID(string id, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.ApprovalHistory, true),
                                                    string.Format(Lists.RestFilters.ByID, id));

                return CRUDOperations.GetListByRestURL<ApprovalHistory>(RestUrl).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public List<ApprovalHistory> GetApprovalHistoryByWorkItemID(string workItemID, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.ApprovalHistory, true),
                                                    string.Format(Lists.RestFilters.ByWorkItemID, workItemID),
                                                    string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<ApprovalHistory>(RestUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public List<ApprovalHistory> GetApprovalHistoryByWorkItemRecordID(string workItemRecordID, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.ApprovalHistory, true),
                                                    string.Format(Lists.RestFilters.ByWorkItemRecordID, workItemRecordID),
                                                    string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<ApprovalHistory>(RestUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public Result AddApprovalHistory(ApprovalHistory objApprovalHistory, string siteUrl)
        {
            Result res = new Result();
            try
            {
                res = CRUDOperations.AddListItem<ApprovalHistory>(Lists.Lists.ApprovalHistory, objApprovalHistory);

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

        //public Result UpdateApprovalHistory(ApprovalHistory objApprovalHistory, string siteUrl)
        //{
        //    Result res = new Result();
        //    try
        //    {
        //        res = CRUDOperations.UpdateListItem<ApprovalHistory>(Lists.Lists.ApprovalHistory, objApprovalHistory);

        //        res.StatusCode = StatusCode.Success;
        //        res.Message = Messages.MsgSuccessUpdate;
        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
        //        res.Message = Messages.MsgSomethingWentWrong;
        //        res.StatusCode = StatusCode.Error;
        //        return res;
        //    }
        //}
    }
}
