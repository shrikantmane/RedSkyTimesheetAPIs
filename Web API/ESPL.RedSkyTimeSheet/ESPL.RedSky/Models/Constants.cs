using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ESPL.RedSkyTimeSheet.Models
{
    public class Constants
    {
        public static string DomainName = Convert.ToString(WebConfigurationManager.AppSettings["DomainName"]);
        public static string QualifiedDomainName = Convert.ToString(WebConfigurationManager.AppSettings["QualifiedDomainName"]);
        public static string SiteUrl = Convert.ToString(WebConfigurationManager.AppSettings["SiteUrl"]);
        public static string ErrorLogPath = Convert.ToString(WebConfigurationManager.AppSettings["ErrorLogPath"]);
        public static string LeaveHRProject = Convert.ToString(WebConfigurationManager.AppSettings["LeaveHRProject"]);
    }
}