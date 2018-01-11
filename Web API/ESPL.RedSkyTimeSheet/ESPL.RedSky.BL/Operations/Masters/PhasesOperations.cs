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
    public class PhasesOperations
    {
        public List<Phases> Phases(string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Phases, true));

                return CRUDOperations.GetListByRestURL<Phases>(RestUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }
        
        public Phases PhaseByID(string id, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Phases, true),
                                                    string.Format(Lists.RestFilters.ByID, id));

                return CRUDOperations.GetListByRestURL<Phases>(RestUrl).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public List<Phases> PhasesByProjectID(string projectID, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Phases, true),
                                                    string.Format(Lists.RestFilters.ByProjectID, projectID),
                                                    string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<Phases>(RestUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public List<Phases> PhasesByProjectName(string projectName, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Phases, true),
                                                    string.Format(Lists.RestFilters.ByProjectName, projectName),
                                                    string.Format(Lists.RestFilters.topItems, GetTop.Default));

                return CRUDOperations.GetListByRestURL<Phases>(RestUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public Result AddPhase(Phases objPhases, string siteUrl)
        {
            Result res = new Result();
            try
            {
                res = CRUDOperations.AddListItem<Phases>(Lists.Lists.Phases, objPhases);

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

        public Result UpdatePhase(Phases objPhases, string siteUrl)
        {
            Result res = new Result();
            try
            {
                res = CRUDOperations.UpdateListItem<Phases>(Lists.Lists.Phases, objPhases);

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
