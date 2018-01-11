using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ESPL.AUTHENTICATION.OWINTOKEN.Models
{
    public class Constants
    {
        public static string DomainName = Convert.ToString(WebConfigurationManager.AppSettings["DomainName"]);
        public static string QualifiedDomainName = Convert.ToString(WebConfigurationManager.AppSettings["QualifiedDomainName"]);
    }
}