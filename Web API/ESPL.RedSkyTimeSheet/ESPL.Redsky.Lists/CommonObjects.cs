using ESPL.SHAREPOINT.RESTSERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPL.RedSkyTimeSheet.Lists
{
    class CommonObjects
    {
    }

    public class Result
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string ReasonCode { get; set; }
        public string ErrorMsg { get; set; }
    }

    public class StatusCode
    {
        public static int Success { get { return 1; } }
        public static int Error { get { return 2; } }
        public static int CannotDelete { get { return 3; } }

    }

    public class GetUserInfo
    {
        public static string LoginName
        {
            get { return Convert.ToString(RestAPI.TryGetClaim("LoginName").Value); }
        }

        public static string UserName
        {
            get { return Convert.ToString(RestAPI.TryGetClaim("UserName").Value); }
        }

        public static string FirstName
        {
            get { return Convert.ToString(RestAPI.TryGetClaim("FirstName").Value); }
        }

        public static string MiddleName
        {
            get { return Convert.ToString(RestAPI.TryGetClaim("MiddleName").Value); }
        }

        public static string LastName
        {
            get { return Convert.ToString(RestAPI.TryGetClaim("LastName").Value); }
        }

        public static int UserID
        {
            get { return Convert.ToInt32(RestAPI.TryGetClaim("UserID").Value); }
        }

        public static string Email
        {
            get { return Convert.ToString(RestAPI.TryGetClaim("Email").Value); }
        }

        public static string EmployeeID
        {
            get { return Convert.ToString(RestAPI.TryGetClaim("EmployeeID").Value); }
        }

        public static string UserRole
        {
            get { return Convert.ToString(RestAPI.TryGetClaim("UserRoles").Value); }
        }

        public static string Approvers
        {
            get { return RestAPI.TryGetClaim("Approvers").Value; }
        }

        public static string Department
        {
            get { return RestAPI.TryGetClaim("Department").Value; }
        }
    }
}
