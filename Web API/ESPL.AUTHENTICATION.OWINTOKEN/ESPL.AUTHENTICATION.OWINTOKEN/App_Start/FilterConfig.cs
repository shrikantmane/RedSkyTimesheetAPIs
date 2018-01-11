using System.Web;
using System.Web.Mvc;

namespace ESPL.AUTHENTICATION.OWINTOKEN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
