using ESPL.RedSkyTimeSheet.ViewModel.GenericViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPL.RedSkyTimeSheet.ViewModel.TimesheetModel
{
    public class EMPTimesheetViewModel : BaseIDViewModel
    {
        public LookupViewModel ApproverUser { get; set; }

        public LookupViewModel Project { get; set; }

        public string Task { get; set; }

        public string Mondayhrs { get; set; }

        public string Mondaydesc { get; set; }

        public string Tuesdayhrs { get; set; }

        public string Tuesdaydesc { get; set; }

        public string Wednesdayhrs { get; set; }

        public string Wednesdaydesc { get; set; }

        public string Thursdayhrs { get; set; }

        public string Thursdaydesc { get; set; }

        public string Fridayhrs { get; set; }

        public string Fridaydesc { get; set; }

        public string Saturdayhrs { get; set; }

        public string Saturdaydesc { get; set; }

        public string Sundayhrs { get; set; }

        public string Sundaydesc { get; set; }

        public string Billable { get; set; }

        public string TimesheetStartDate { get; set; }

        public string TimesheetEndDate { get; set; }

        public string TimesheetID { get; set; }

        public string Mondaynbhrs { get; set; }

        public string Tuesdaynbhrs { get; set; }

        public string Wednesdaynbhrs { get; set; }

        public string Thursdaynbhrs { get; set; }

        public string Fridaynbhrs { get; set; }

        public string Saturdaynbhrs { get; set; }

        public string Sundaynbhrs { get; set; }

        public string WeekNumber { get; set; }

        public string ProjectTimesheetStatus { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Mondaydescnb { get; set; }

        public string Tuesdaydescnb { get; set; }

        public string Wednesdaydescnb { get; set; }

        public string Thursdaydescnb { get; set; }

        public string Fridaydescnb { get; set; }

        public string Saturdaydescnb { get; set; }

        public string Sundaydescnb { get; set; }

        public string ApproverComment { get; set; }

        public string TimesheetStatus { get; set; }

        public string UpdationFlag { get; set; }
    }

    public class TimesheetViewModel : BaseIDViewModel
    {
        public string Title { get; set; }

        public LookupViewModel Employee { get; set; }

        public string EmployeeID { get; set; }

        public string RecordID { get; set; }

        public string Status { get; set; }

        public DateTime? WeekStartDate { get; set; }

        public DateTime? WeekEndDate { get; set; }
    }

    //public class WorkItemsViewModel : BaseIDViewModel
    //{
    //    public DateTime? Date { get; set; }

    //    public LookupViewModel Project { get; set; }

    //    public LookupViewModel Phase { get; set; }

    //    public LookupViewModel Task { get; set; }

    //    public int? BillableHrs { get; set; }

    //    public int? NonBillableHrs { get; set; }

    //    public string Description { get; set; }

    //    public string Staus { get; set; }

    //    public string Approver { get; set; }

    //    public string ApprovalComments { get; set; }

    //    public DateTime? ApprovalOn { get; set; }

    //    public LookupViewModel TimesheetID { get; set; }
    //}

    //public class TimesheetWithWorkItemsViewModel : TimesheetViewModel
    //{
    //    public List<WorkItemsViewModel> TimesheetWithWorkItems { get; set; }
    //}

    public class WorkItemStatusAndTimesheetID
    {
        public string Status { get; set; }
        public LookupViewModel TimesheetID { get; set; }
    }

    public class ApproverTimesheetViewModel
    {
        public string ID { get; set; }
        public string ApproverRemarks { get; set; }
        public string Approver { get; set; }
        public DateTime? ApprovedOn { get; set; }
    }

    public class DetailedTimesheetByProejct_Phase_Task
    {
        public LookupViewModel Project { get; set; }
        public LookupViewModel Phase { get; set; }
        public LookupViewModel Task { get; set; }
        public string Status { get; set; }

        //public LookupViewModel Employee { get; set; }
        //public DateTime WeekStartDate { get; set; }
    }

    public class TimesheetByEmployeeAndStartDateAndStatusViewModel
    {
        public LookupViewModel Employee { get; set; }
        public DateTime WeekStartDate { get; set; }
        public string Status { get; set; }
        public string RecordID { get; set; }
    }

    public class SyncRecordID
    {
        public int ID { get; set; }
        public string RecordID { get; set; }
    }

    public class SyncRecordIDWrapper
    {
        public List<SyncRecordID> RecordIds { get; set; }
    }

    public class SyncStatus
    {
        public int ID { get; set; }
        public int IsSynced { get; set; }
    }
    public class SyncStatusModelView
    {
        public List<SyncStatus> Records { get; set; }
    }
    public class SyncStatusByRecordID
    {
        public string RecordID { get; set; }
        public int IsSynced { get; set; }
    }
    public class SyncStatusByRecordIDModelView
    {
        public List<SyncStatusByRecordID> Records { get; set; }
    }
    public class WorkItemsByDateEmployeeProejctPhaseTask
    {
        public LookupViewModel Employee { get; set; }
        public LookupViewModel Project { get; set; }
        public LookupViewModel Phase { get; set; }
        public LookupViewModel Task { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string RecordID { get; set; }

    }
}
