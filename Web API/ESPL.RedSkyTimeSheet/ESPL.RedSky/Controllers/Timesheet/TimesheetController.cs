using ESPL.RedSkyTimeSheet.BL.Operations.Timesheets;
using ESPL.RedSkyTimeSheet.ViewModel.TimesheetModel;
using ESPL.RedSkyTimeSheet.Models;
using System.Web;
using System.Web.Http;

namespace ESPL.LINKUP.Controllers.Timesheet
{
    [Route("api/Timesheet")]
    public class TimesheetController : ApiController
    {
        TimesheetOperations objTimesheetOperations = new TimesheetOperations();
        public string accessToken = (HttpContext.Current.Request.Headers["Authorization"]).Split(' ')[1];

        [Authorize]
        [HttpGet]
        [Route("api/Timesheet")]
        public IHttpActionResult Get()
        {
            return Ok(objTimesheetOperations.GetTimesheetItems(Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Timesheet/{id}")]
        public IHttpActionResult Get(string id)
        {
            return Ok(objTimesheetOperations.GetTimesheetByID(id, Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Timesheet/GetTimesheetByRecordID/{id}")]
        public IHttpActionResult GetWorkItemsByRecordID(string id)
        {
            return Ok(objTimesheetOperations.GetTimesheetByRecordID(id, Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Timesheet/GetTimesheetByStatus/{status}")]
        public IHttpActionResult GetTimesheetByStatus(string status)
        {
            return Ok(objTimesheetOperations.GetTimesheetByStatus(status, Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Timesheet/GetTimesheetBySyncStatus/{status}")]
        public IHttpActionResult GetTimesheetBySyncStatus(int status)
        {
            return Ok(objTimesheetOperations.GetTimesheetBySyncStatus(status, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Timesheet/GetTimesheetsByEmployeeAndWeekStartDateAndStatus")]
        public IHttpActionResult GetTimesheetsByEmployeeAndWeekStartDateAndStatus(TimesheetByEmployeeAndStartDateAndStatusViewModel timesheetObj)
        {
            return Ok(objTimesheetOperations.GetTimesheetsByEmployeeAndWeekStartDateAndStatus(timesheetObj, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Timesheet/GetTimesheetsByEmployeeAndWeekStartDate")]
        public IHttpActionResult GetTimesheetsByEmployeeAndWeekStartDate(TimesheetByEmployeeAndStartDateAndStatusViewModel timesheetObj)
        {
            return Ok(objTimesheetOperations.GetTimesheetsByEmployeeAndWeekStartDate(timesheetObj, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Timesheet/GetTimesheetsByEmployeeAndStatus")]
        public IHttpActionResult GetTimesheetsByEmployeeAndStatus(TimesheetByEmployeeAndStartDateAndStatusViewModel timesheetObj)
        {
            return Ok(objTimesheetOperations.GetTimesheetsByEmployeeAndStatus(timesheetObj, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Timesheet/GetTimesheetsByWeekStartDateAndStatus")]
        public IHttpActionResult GetTimesheetsByWeekStartDateAndStatus(TimesheetByEmployeeAndStartDateAndStatusViewModel timesheetObj)
        {
            return Ok(objTimesheetOperations.GetTimesheetsByWeekStartDateAndStatus(timesheetObj, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Timesheet/GetTimesheetsByWeekStartDate")]
        public IHttpActionResult GetTimesheetsByWeekStartDate(TimesheetByEmployeeAndStartDateAndStatusViewModel timesheetObj)
        {
            return Ok(objTimesheetOperations.GetTimesheetsByWeekStartDate(timesheetObj, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Timesheet/UpdateTimesheetRecordId")]
        public IHttpActionResult UpdateTimesheetRecordId(SyncRecordIDWrapper objTimesheet)
        {
            return Ok(objTimesheetOperations.UpdateTimesheetRecordId(objTimesheet.RecordIds, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Timesheet/UpdateTimesheetRecordIdByEmployeeAndWeekStartDate")]
        public IHttpActionResult UpdateTimesheetRecordIdByEmployeeAndWeekStartDate(TimesheetByEmployeeAndStartDateAndStatusViewModel objTimesheet)
        {
            return Ok(objTimesheetOperations.UpdateTimesheetRecordIdByEmployeeAndWeekStartDate(objTimesheet, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Timesheet/Sync")]
        public IHttpActionResult Sync(SyncStatusModelView objRecords)
        {
            return Ok(objTimesheetOperations.UpdateTimesheetSyncStatus(objRecords.Records, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Timesheet/SyncByRecordID")]
        public IHttpActionResult SyncByRecordID(SyncStatusByRecordIDModelView objRecords)
        {
            return Ok(objTimesheetOperations.UpdateTimesheetSyncStatusByRecordID(objRecords.Records, Constants.SiteUrl));
        }
    }
}
