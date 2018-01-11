using ESPL.RedSkyTimeSheet.BL.Operations.Timesheets;
using ESPL.RedSkyTimeSheet.ViewModel.TimesheetModel;
using ESPL.RedSkyTimeSheet.Models;
using System.Web;
using System.Web.Http;


namespace ESPL.RedSkyTimeSheet.Controllers.Timesheet
{
    [Route("api/WorkItems")]
    public class WorkItemsController : ApiController
    {
        WorkItemsOperations objWorkItemsOperations = new WorkItemsOperations();
        public string accessToken = (HttpContext.Current.Request.Headers["Authorization"]).Split(' ')[1];

        [Authorize]
        [HttpGet]
        [Route("api/WorkItems")]
        public IHttpActionResult Get()
        {
            return Ok(objWorkItemsOperations.GetWorkItems(Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/WorkItems/{id}")]
        public IHttpActionResult Get(string id)
        {
            return Ok(objWorkItemsOperations.GetWorkItemsByID(id, Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/WorkItems/GetWorkItemsByRecordID/{id}")]
        public IHttpActionResult GetWorkItemsByRecordID(string id)
        {
            return Ok(objWorkItemsOperations.GetWorkItemsByRecordID(id, Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/WorkItems/GetWorkItemsByTimesheetID/{id}")]
        public IHttpActionResult GetWorkItemsByTimesheetID(string id)
        {
            return Ok(objWorkItemsOperations.GetWorkItemsByTimesheetID(id, Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/WorkItems/GetWorkItemsByStatus/{status}")]
        public IHttpActionResult GetWorkItemsByStatus(string status)
        {
            return Ok(objWorkItemsOperations.GetWorkItemsByStatus(status, Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/WorkItems/GetWorkItemsBySyncStatus/{syncStatus}")]
        public IHttpActionResult GetWorkItemsBySyncStatus(int syncStatus)
        {
            return Ok(objWorkItemsOperations.GetWorkItemsBySyncStatus(syncStatus, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/WorkItems/GetWorkItemsByStatusAndTimesheetID")]
        public IHttpActionResult GetWorkItemsByStatusAndTimesheetID(WorkItemStatusAndTimesheetID objStatusTimesheetID)
        {
            return Ok(objWorkItemsOperations.GetWorkItemsByStatusAndTimesheetID(objStatusTimesheetID, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/WorkItems/GetWorkItemsByDateEmployeeProjectPhaseTask")]
        public IHttpActionResult GetWorkItemsByDateEmployeeProjectPhaseTask(WorkItemsByDateEmployeeProejctPhaseTask objWeekItem)
        {
            return Ok(objWorkItemsOperations.GetWorkItemsByDateEmployeeProjectPhaseTask(objWeekItem, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/WorkItems/UpdateWorkItemRecordIDUniquely")]
        public IHttpActionResult UpdateWorkItemRecordIDUniquely(WorkItemsByDateEmployeeProejctPhaseTask objWorkItem)
        {
            return Ok(objWorkItemsOperations.UpdateWorkItemRecordIDUniquely(objWorkItem, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/WorkItems/UpdateWorkItemRecordId")]
        public IHttpActionResult UpdateWorkItemRecordId(SyncRecordIDWrapper objApprovalData)
        {
            return Ok(objWorkItemsOperations.UpdateWorkItemRecordId(objApprovalData.RecordIds, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/WorkItems/Sync")]
        public IHttpActionResult Sync(SyncStatusModelView objRecords)
        {
            return Ok(objWorkItemsOperations.UpdateWorkItemSyncStatus(objRecords.Records, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/WorkItems/SyncByRecordID")]
        public IHttpActionResult SyncByRecordID(SyncStatusByRecordIDModelView objRecords)
        {
            return Ok(objWorkItemsOperations.UpdateWorkItemSyncStatusByRecordID(objRecords.Records, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/WorkItems/Approve")]
        public IHttpActionResult ApproveWorkItemsByID(ApproverTimesheetViewModel objApprovalData)
        {
            return Ok(objWorkItemsOperations.ApproveWorkItemsByID(objApprovalData, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/WorkItems/ApproveByRecordID")]
        public IHttpActionResult ApproveWorkItemsByRecordID(ApproverTimesheetViewModel objApprovalData)
        {
            return Ok(objWorkItemsOperations.ApproveWorkItemsByRecordID(objApprovalData, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/WorkItems/Reject")]
        public IHttpActionResult RejectWorkItems(ApproverTimesheetViewModel objApprovalData)
        {
            return Ok(objWorkItemsOperations.RejectWorkItems(objApprovalData, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/WorkItems/RejectByRecordID")]
        public IHttpActionResult RejectWorkItemsByRecordID(ApproverTimesheetViewModel objApprovalData)
        {
            return Ok(objWorkItemsOperations.RejectWorkItemsByRecordID(objApprovalData, Constants.SiteUrl));
        }

    }
}
