using System.Web;
using System.Web.Mvc;

namespace TechFix_Supplier_Consumer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
