using System.Web.Mvc;

namespace Bizagi.Business.Reports.Areas._ViewStart
{
    public class _ViewStartAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "_ViewStart";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "_ViewStart_default",
                "_ViewStart/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}