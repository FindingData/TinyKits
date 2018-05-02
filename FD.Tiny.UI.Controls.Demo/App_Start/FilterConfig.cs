using System.Web;
using System.Web.Mvc;

namespace FD.Tiny.UI.Controls.Demo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
