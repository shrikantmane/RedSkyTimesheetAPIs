using System;
using System.Collections.Generic;
using ESPL.SHAREPOINT.RESTSERVICE;
using ESPL.RedSkyTimeSheet.Lists;
namespace ESPL.RedSkyTimeSheet.BL.Models
{
    public class UserInformation : User
    {
        public long UserID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string EmployeeId { get; set; }
        public string Department { get; set; }
        public string UserRole { get; set; }
        public string Approvers { get; set; }
    }

    public class IDs
    {
        public string ID { get; set; }
    }

    public class TimesheetStatus
    {
        public const string Submitted = "Submitted";
        public const string Approved = "Approved";
        public const string Rejected = "Rejected";
        public const string Draft = "Draft";
    }
}
