using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ESPL.RedSkyTimeSheet.Lists
{
    public class TimesheetObjects
    {
    }


    public class Timesheet : Base
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Employee")]
        public User Employee { get; set; }

        [JsonProperty("Employee_x0020_ID")]
        public string _EmployeeID { set { EmployeeID = value; } }
        [JsonProperty("EmployeeID")]
        public string EmployeeID { get; private set; }

        [JsonProperty("Record_x0020_ID")]
        public string _RecordID { set { RecordID = value; } }
        [JsonProperty("RecordID")]
        public string RecordID { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Week_x0020_Start_x0020_Date")]
        public DateTime? _WeekStartDate { set { WeekStartDate = value; } }
        [JsonProperty("WeekStartDate")]
        public DateTime? WeekStartDate { get; set; }

        [JsonProperty("Week_x0020_End_x0020_Date")]
        public DateTime? _WeekEndDate { set { WeekEndDate = value; } }
        [JsonProperty("WeekEndDate")]
        public DateTime? WeekEndDate { get; set; }

        [JsonProperty("IsSynced")]
        public int? IsSynced { get; set; }
    }

    public class WorkItems : Base
    {
        [JsonProperty("Work_x0020_Date")]
        public DateTime? _WorkDate { set { WorkDate = value; } }
        [JsonProperty("WorkDate")]
        public DateTime? WorkDate { get; private set; }

        [JsonProperty("Project")]
        public TitleLookup Project { get; set; }

        [JsonProperty("Phase")]
        public TitleLookup Phase { get; set; }

        [JsonProperty("Task")]
        public TitleLookup Task { get; set; }

        [JsonProperty("Billable_x0020_Hrs")]
        public int? _BillableHrs { set { BillableHrs = value; } }
        [JsonProperty("BillableHrs")]
        public int? BillableHrs { get; set; }

        [JsonProperty("Non_x0020_Billable_x0020_Hrs")]
        public int? _NonBillableHrs { set { NonBillableHrs = value; } }
        [JsonProperty("NonBillableHrs")]
        public int? NonBillableHrs { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Status")]
        public string Staus { get; set; }

        [JsonProperty("Approver")]
        public string Approver { get; set; }

        [JsonProperty("Approval_x0020_Comments")]
        public string _ApprovalComments { set { ApprovalComments = value; } }
        [JsonProperty("ApprovalComments")]
        public string ApprovalComments { get; set; }

        [JsonProperty("Approval_x0020_On")]
        public DateTime? _ApprovalOn { set { ApprovalOn = value; } }
        [JsonProperty("ApprovalOn")]
        public DateTime? ApprovalOn { get; set; }

        [JsonProperty("Timesheet_x0020_ID")]
        public FieldIDLookup _TimesheetID { set { TimesheetID = value; } }
        [JsonProperty("TimesheetID")]
        public FieldIDLookup TimesheetID { get; set; }

        [JsonProperty("IsSynced")]
        public int? IsSynced { get; set; }

        [JsonProperty("Record_x0020_ID")]
        public string _RecordID { set { RecordID = value; } }
        [JsonProperty("RecordID")]
        public string RecordID { get; set; }

    }

    public class TimesheetWithWorkItems : Timesheet
    {
        public List<WorkItems> WorkItems { get; set; }
    }
    //public class RSTimesheets : Base
    //{
    //    [JsonProperty("Project")]
    //    public TitleLookup Project { get; set; }

    //    [JsonProperty("Phase_x0020_ID")]
    //    public TitleLookup PhaseID { get; set; }

    //    [JsonProperty("Engagement")]
    //    public TitleLookup Engagement { get; set; }

    //    [JsonProperty("Task_x0020_ID")]
    //    public TitleLookup TaskID { get; set; }

    //    [JsonProperty("Week_x0020_Start_x0020_Date")]
    //    public DateTime? _StartDate { get; set; }

    //    [JsonProperty("Week_x0020_End_x0020_Date")]
    //    public DateTime? _EndDate { get; set; }

    //    [JsonProperty("Approver")]
    //    public string Approver { get; set; }

    //    [JsonProperty("Approver_x0020_Remark")]
    //    public string ApproverRemark { get; set; }

    //    [JsonProperty("Employee")]
    //    public TitleLookup Employee { get; set; }

    //    [JsonProperty("Employee_x0020_ID")]
    //    public string EmployeeID { get; set; }

    //    [JsonProperty("Status")]
    //    public string Status { get; set; }

    //    [JsonProperty("RecordID")]
    //    public string RecordID { get; set; }

    //    [JsonProperty("Mon_x0020_Date")]
    //    public DateTime? MondayDate { get; set; }

    //    [JsonProperty("Mon_x0020_B_x0020_Hrs")]
    //    public string MondayBillableHrs { get; set; }

    //    [JsonProperty("Mon_x0020_NB_x0020_Hrs")]
    //    public string MondayNonBillableHrs { get; set; }

    //    [JsonProperty("Mon_x0020_Desc")]
    //    public string MondayDescription { get; set; }

    //    [JsonProperty("Tues_x0020_Date")]
    //    public DateTime? TuesdayDate { get; set; }

    //    [JsonProperty("Tues_x0020_B_x0020_Hrs")]
    //    public string TuesdayBillableHrs { get; set; }

    //    [JsonProperty("Tues_x0020_NB_x0020_Hrs")]
    //    public string TuesdayNonBillableHrs { get; set; }

    //    [JsonProperty("Tues_x0020_Desc")]
    //    public string TuesdayDescription { get; set; }

    //    [JsonProperty("Wed_x0020_Date")]
    //    public DateTime? WednesdayDate { get; set; }

    //    [JsonProperty("Wed_x0020_B_x0020_Hrs")]
    //    public string WednesdayBillableHrs { get; set; }

    //    [JsonProperty("Wed_x0020_NB_x0020_Hrs")]
    //    public string WednesdayNonBillableHrs { get; set; }

    //    [JsonProperty("Wed_x0020_Desc")]
    //    public string WednesdayDescription { get; set; }

    //    [JsonProperty("Thurs_x0020_Date")]
    //    public DateTime? ThursdayDate { get; set; }

    //    [JsonProperty("Thurs_x0020_B_x0020_Hrs")]
    //    public string ThursdayBillableHrs { get; set; }

    //    [JsonProperty("Thurs_x0020_NB_x0020_Hrs")]
    //    public string ThursdayNonBillableHrs { get; set; }

    //    [JsonProperty("Thurs_x0020_Desc")]
    //    public string ThursdayDescription { get; set; }

    //    [JsonProperty("Fri_x0020_Date")]
    //    public DateTime? FridayDate { get; set; }

    //    [JsonProperty("Fri_x0020_B_x0020_Hrs")]
    //    public string FridayBillableHrs { get; set; }

    //    [JsonProperty("Fri_x0020_Desc")]
    //    public string FridayDescription { get; set; }

    //    [JsonProperty("Last_x0020_Approved_x0020_On")]
    //    public DateTime? LastApprovedOn { get; set; }
    //}
}
