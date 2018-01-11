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
    public class TasksOperations
    {
        public List<Tasks> Tasks(string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Tasks, true));

                return CRUDOperations.GetListByRestURL<Tasks>(RestUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public Tasks TaskByID(string id, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Tasks, true),
                                                    string.Format(Lists.RestFilters.ByID, id));

                return CRUDOperations.GetListByRestURL<Tasks>(RestUrl).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public List<Tasks> TasksByPhaseID(string phaseID, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Tasks, true),
                                                    string.Format(Lists.RestFilters.ByPhaseID, phaseID),
                                                    string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<Tasks>(RestUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public List<Tasks> TasksByPhaseName(string phaseName, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Tasks, true),
                                                    string.Format(Lists.RestFilters.ByPhaseName, phaseName),
                                                    string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<Tasks>(RestUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public Result AddTask(Tasks objTask, string siteUrl)
        {
            Result res = new Result();
            try
            {
                res = CRUDOperations.AddListItem<Tasks>(Lists.Lists.Tasks, objTask);

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

        public Result UpdateTask(Tasks objTask, string siteUrl)
        {
            Result res = new Result();
            try
            {
                res = CRUDOperations.UpdateListItem<Tasks>(Lists.Lists.Tasks, objTask);

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
