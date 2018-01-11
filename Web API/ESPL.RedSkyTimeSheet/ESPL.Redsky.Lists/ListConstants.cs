
namespace ESPL.RedSkyTimeSheet.Lists
{
    public class GetTop
    {
        public const string _100 = "100";
        public const string _250 = "250";
        public const string _500 = "500";
        public const string _1000 = "1000";
        public const string _5000 = "5000";
        public const string _10000 = "10000";
        public const string _50000 = "50000";
        public const string Default = "10000";
    }

    public class ListDataTypes
    {
        public static string TextType = "Text";
        public static string MultipleLookupType = "LookupMulti";
        public static string LookupType = "Lookup";
    }

    public class Lists
    {
        //RED SKY
        //public const string Timesheet = "Timesheet";
        public const string WorkItems = "Work Items";
        public const string Timesheet = "Timesheet";
        public const string Phases = "Phases";
        public const string Projects = "Projects";
        public const string Tasks = "Tasks";
        public const string Engagements = "Engagements";
        public const string ApprovalHistory = "History";
    }

    public class SelectExpandListFields
    {
        public static string WorkItems = "?$select=Employee/Id, Employee/Title,Phase/Title,Phase/Id,Task/Title,Task/Id, Project/Id,Project/Title,Timesheet_x0020_ID/Id,Timesheet_x0020_ID/Title,Author/Id,Author/Title,Editor/Id,Editor/Title,*&$expand=Employee,Project,Timesheet_x0020_ID,Phase,Task,Author,Editor";
        public static string Timesheet = "?$select=Employee/Id, Employee/Title,Author/Id,Author/Title,Editor/Id,Editor/Title,*&$expand=Employee,Author,Editor";
        public static string Engagements = "?$select=Project/Id,Project/Title,Author/Id,Author/Title,Editor/Id,Editor/Title,*&$expand=Project,Author,Editor";
        public static string Phases = "?$select=Project/Id,Project/Title,Author/Id,Author/Title,Editor/Id,Editor/Title,*&$expand=Project,Author,Editor";
        public static string Tasks = "?$select=Phase/Id,Phase/Title,Author/Id,Author/Title,Editor/Id,Editor/Title,*&$expand=Phase,Author,Editor";
        public static string ApprovalHistory = "?$select=Child_x0020_ID/Id,Child_x0020_ID/Title, Child_x0020_ID/Record_x0020_ID,Author/Id,Author/Title,Editor/Id,Editor/Title,*&$expand=Child_x0020_ID,Author,Editor";
    }

    public class Messages
    {
        /// <summary>
        /// An error occurred while reading data. GUID: {0}
        /// </summary>
        public const string MsgExceptionOccured = "An error occurred while reading data. GUID: {0}";
        /// <summary>
        /// Details added successfully
        /// </summary>
        public const string MsgSuccessAdd = "Details added successfully";
        /// <summary>
        /// Details updated successfully
        /// </summary>
        public const string MsgSuccessUpdate = "Details updated successfully";
        /// <summary>
        /// Details deleted successfully
        /// </summary>
        public const string MsgSuccessDelete = "Details deleted successfully";
        /// <summary>
        /// Something went wrong
        /// </summary>
        public const string MsgSomethingWentWrong = "Something went wrong";
        /// <summary>
        /// No record Found
        /// </summary>
        public const string NoDataFound = "No record found";

        /// <summary>
        /// Records updated
        /// </summary>
        public const string MsgSuccessRecordsUpdate = "Records updated";
    }

    public class RestFilters
    {
        public const string topItems = "&$top={0}";
        public const string ByID = "&$filter=ID eq '{0}'";
        public const string ByTimesheetID = "&$filter=Timesheet_x0020_ID/Id eq '{0}'";
        public const string ByTitle = "&$filter=Title eq '{0}'";
        public const string ByRecordID = "&$filter=Record_x0020_ID eq '{0}'";
        public const string ByStatus = "&$filter= Status eq '{0}'";
        public const string BySyncStatus = "&$filter= IsSynced eq {0}";
        public const string ByStatusTimesheetID = "&$filter= Timesheet_x0020_ID/Id eq '{0}' and Status eq '{1}'";

        public const string ByEnagagementTaskIDWeekStartDate = "&$filter=Employee/Id eq '{0}' and Engagement/Id eq '{1}' and Task_x0020_ID/Id eq '{2}' and Week_x0020_Start_x0020_Date eq '{3}'";
        public const string ByTimesheetByStartDateEndDateStatus = "&$filter= Status eq '{0}' and Week_x0020_Start_x0020_Date ge '{1}' and Week_x0020_End_x0020_Date le '{2}'";

        public const string ByProjectID = "&$filter=Project/Id eq '{0}'";
        public const string ByProjectName = "&$filter=Project/Title eq '{0}'";

        public const string ByPhaseID = "&$filter=Phase/Id eq '{0}'";
        public const string ByPhaseName = "&$filter=Phase/Title eq '{0}'";

        public const string ByEngagementID = "&$filter=Engagement/Id eq '{0}'";
        public const string ByEngagementName = "&$filter=Engagement/Title eq '{0}'";

        public const string ByWorkItemID = "&$filter=Child_x0020_ID/Id eq '{0}'";
        public const string ByWorkItemRecordID = "&$filter=Child_x0020_ID/Record_x0020_ID eq '{0}'";

        public const string ByEmployeeAndStartDateAndStatus = "&$filter=Employee/Id eq '{0}' and Week_x0020_Start_x0020_Date eq datetime'{1}' and Status eq '{2}'";
        public const string ByEmployeeAndStartDate = "&$filter=Employee/Id eq '{0}' and Week_x0020_Start_x0020_Date eq datetime'{1}'";
        public const string ByEmployeeAndStatus = "&$filter=Employee/Id eq '{0}' and Status eq '{1}'";
        public const string ByStartDateAndStatus = "&$filter= Week_x0020_Start_x0020_Date eq datetime'{0}' and Status eq '{1}'";
        public const string ByStartDate = "&$filter=Week_x0020_Start_x0020_Date eq datetime'{0}'";
        public const string WorkItemsByDate_Employee_Proejct_Phase_Task = "&$filter=Date eq '{0}' and Employee/Id eq '{1}' and  Project/Id eq '{2}' and Phase/Id eq '{3}' and Task/Id  eq '{4}' ";


    }

}
