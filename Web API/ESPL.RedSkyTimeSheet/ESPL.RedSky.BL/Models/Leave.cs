using ESPL.RedSkyTimeSheet.Lists;
using System;
using System.Collections.Generic;

namespace ESPL.RedSkyTimeSheet.BL.Models
{
    ///// <summary>
    ///// This class holds property from <Leave Request Master> list from sharepoint.
    ///// </summary>
    //class LeaveDetails : Base
    //{
    //    public int Id { get; set; }
    //    public string Department { get; set; }
    //    public DateTime StartDate { get; set; }
    //    public DateTime EndDate { get; set; }
    //    /// <summary>
    //    /// **FL :: Fixed Holiday
    //    /// </summary>
    //    public string FHTotal { get; set; }
    //    /// <summary>
    //    /// **HA :: 
    //    /// </summary>
    //    public string HATotal { get; set; }
    //    /// <summary>
    //    /// **HL :: Half day Leave
    //    /// </summary>
    //    public string HLTotal { get; set; }
    //    /// <summary>
    //    /// Total number of leaves consumed
    //    /// </summary>
    //    public string LTotal { get; set; }
    //    public string LeaveRequestCode { get; set; }
    //    public string NumberOfDays { get; set; }
    //    public string NumberOfLeaves { get; set; }
    //    public string Status { get; set; }
    //    /// <summary>
    //    /// Managers Comments holds multiline text in sharepoint
    //    /// </summary>
    //    public string ManagersComments { get; set; }
    //    /// <summary>
    //    /// Applicant property holds Employee object who applied for leave.
    //    /// </summary>
    //    public Employee Applicant { get; set; }
    //    public List<User> Approvers { get; set; }
    //    public List<User> PendingApprovers { get; set; }
    //    public List<User> ReportingManager { get; set; }

    //}
    ///// <summary>
    ///// This class holds property from <LeaveTypeMaster> list from sharePoint
    ///// </summary>
    //class LeaveType : Base
    //{
    //    public string Type { get; set; }
    //    public string Code { get; set; }
    //    public string Value { get; set; }
    //    public bool IsApplicable { get; set; }
    //    public bool CanAdjusted { get; set; }
    //}
    ///// <summary>
    ///// This class holds property from <Leave Request Details> list from sharepoint.
    ///// </summary>
    //class Leave : Base
    //{
    //    public string Day { get; set; }
    //    /// <summary>
    //    /// Applicant property holds Employee object who applied for leave.
    //    /// </summary>
    //    public Employee Applicant { get; set; }
    //    public DateTime StartDate { get; set; }
    //    public DateTime EndDate { get; set; }
    //    public LeaveType Type { get; set; }
    //    public string NumberOfDays { get; set; }
    //    public string Reason { get; set; }
    //    public string Status { get; set; }
    //    /// <summary>
    //    /// Leave Request details ID
    //    /// </summary>
    //    public string LeaveDetailsCode { get; set; }
    //    /// <summary>
    //    /// Leave request Ref ID
    //    /// </summary>
    //    public string LeaveCode { get; set; }
    //}
    ///// <summary>
    ///// This class holds property from <Holiday> list from sharepoint.
    ///// </summary>
    //class Holiday : Base
    //{
    //    public DateTime HolidayDate { get; set; }
    //    public String HolidayDescription { get; set; }
    //    public User HolidayType { get; set; }
    //    public User FiscalYear { get; set; }
    //}
    ///// <summary>
    ///// Holds information about Leave approvers <Leave Request Approvers Master>
    ///// </summary>
    //class LeaveApprovers : Base
    //{
    //    public string NumberOfDays { get; set; }
    //    public string Comments { get; set; }
    //    public Employee Employee { get; set; }
    //    public Employee Approver { get; set; }
    //    public DateTime StartDate { get; set; }
    //    public DateTime EndDate { get; set; }
    //    /// <summary>
    //    /// Leave request Ref ID
    //    /// </summary>
    //    public string LeaveCode { get; set; }
    //}
    /// <summary>
    /// Hold the list of properties to get information about Project Members <Project Team Members>
    /// </summary>
    class ProjectMembers
    {
        public string ProjectCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public User TeamMemeber { get; set; }
    }

}
