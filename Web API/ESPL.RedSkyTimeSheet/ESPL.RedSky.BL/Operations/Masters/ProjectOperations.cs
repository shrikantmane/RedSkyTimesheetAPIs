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
    public class ProjectOperations
    {
        public List<Projects> Projects(string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Projects, true));

                return CRUDOperations.GetListByRestURL<Projects>(RestUrl);
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public Projects ProjectByID(string id, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Projects, true),
                                                    string.Format(Lists.RestFilters.ByID, id));

                return CRUDOperations.GetListByRestURL<Projects>(RestUrl).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public Projects ProjectByName(string projectName, string siteUrl)
        {
            try
            {
                string RestUrl = string.Concat(siteUrl, Lists.ListURLs.RestUrlListItemWithQuery(Lists.Lists.Projects, true),
                                                    string.Format(Lists.RestFilters.ByTitle, projectName));

                return CRUDOperations.GetListByRestURL<Projects>(RestUrl).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public Result AddProject(Projects objProjects, string siteUrl)
        {
            Result res = new Result();
            try
            {
                res = CRUDOperations.AddListItem<Projects>(Lists.Lists.Projects, objProjects);

                res.StatusCode = StatusCode.Success;
                //res.Message = Messages.MsgProjectCategoryAddSuccess;
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

        public Result UpdateProject(Projects objProjects, string siteUrl)
        {
            Result res = new Result();
            try
            {
                res = CRUDOperations.UpdateListItem<Projects>(Lists.Lists.Projects, objProjects);

                res.StatusCode = StatusCode.Success;
                //res.Message = Messages.MsgProjectCategoryUpdateSuccess;
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
