using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPL.RedSkyTimeSheet.Lists
{
    class Masters
    {
    }

    public class Projects : BaseID
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Project_x0020_Start_x0020_Date")]
        public DateTime? _projectStartDate { set { ProjectStartDate = value; } }
        [JsonProperty("ProjecStartDate")]
        public DateTime? ProjectStartDate { get; set; }

        [JsonProperty("Project_x0020_End_x0020_Date")]
        public DateTime? _projectEndDate { set { ProjectEndDate = value; } }
        [JsonProperty("ProjectEndDate")]
        public DateTime? ProjectEndDate { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Record_x0020_ID")]
        public string _RecordID { set { RecordID = value; } }
        [JsonProperty("RecordID")]
        public string RecordID { get; private set; }

    }

    public class Phases : BaseID
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Project")]
        public TitleLookup Project { get; set; }

        [JsonProperty("Completed_x0020__x0025_")]
        public int? _CompletedPercentage { set { CompletedPercentage = value; } }
        [JsonProperty("CompletedPercentage")]
        public int? CompletedPercentage { get; private set; }

        [JsonProperty("Phase_x0020_Start_x0020_Date")]
        public DateTime? _PhaseStartDate { set { PhaseStartDate = value; } }
        [JsonProperty("PhaseStartDate")]
        public DateTime? PhaseStartDate { get; set; }

        [JsonProperty("Phase_x0020_End_x0020_Date")]
        public DateTime? _PhaseEndDate { set { PhaseEndDate = value; } }
        [JsonProperty("PhaseEndDate")]
        public DateTime? PhaseEndDate { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Record_x0020_ID")]
        public string _RecordID { set { RecordID = value; } }
        [JsonProperty("RecordID")]
        public string RecordID { get; private set; }

    }

    public class Engagements : BaseID
    {
        [JsonProperty("Title")]
        public string Title { get; set; }
        public TitleLookup Project { get; set; }
    }

    public class Tasks : BaseID
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Phase")]
        public TitleLookup Phase { get; set; }

        [JsonProperty("Completed_x0020_Date")]
        public DateTime? _CompletedDate { set { CompletedDate = value; } }
        [JsonProperty("CompletedDate")]
        public DateTime? CompletedDate { get; private set; }

        [JsonProperty("Estimated_x0020_Hrs")]
        public int? _EstimatedHrs { set { EstimatedHrs = value; } }
        [JsonProperty("EstimatedHrs")]
        public int? EstimatedHrs { get; private set; }

        [JsonProperty("Entered_x0020_Hrs")]
        public int? _EnteredHrs { set { EnteredHrs = value; } }
        [JsonProperty("EnteredHrs")]
        public int? EnteredHrs { get; private set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Record_x0020_ID")]
        public string _RecordID { set { RecordID = value; } }
        [JsonProperty("RecordID")]
        public string RecordID { get; private set; }
    }

    public class ApprovalHistory : BaseID
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Child_x0020_ID")]
        public TitleLookup _ChildID { set { ChildID = value; } }
        [JsonProperty("ChildID")]
        public TitleLookup ChildID { get; private set; }

        [JsonProperty("Approver")]
        public string Approver { get; set; }

        [JsonProperty("Approval_x0020_On")]
        public DateTime? _ApprovalOn { set { ApprovalOn = value; } }
        [JsonProperty("ApprovalOn")]
        public DateTime? ApprovalOn { get; private set; }

        [JsonProperty("Approval_x0020_Comments")]
        public string _ApprovalComments { set { ApprovalComments = value; } }
        [JsonProperty("ApprovalComments")]
        public string ApprovalComments { get; private set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

    }
}
