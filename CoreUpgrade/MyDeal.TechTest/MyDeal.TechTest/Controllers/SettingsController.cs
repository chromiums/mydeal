using Microsoft.AspNetCore.Mvc;

namespace MyDeal.TechTest.Controllers
{
    public class SettingsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Json(new SettingsVm
            {
                User = UserService.GetUserDetails("2")?.Data,
                Message = ConfigurationManager.AppSettings["Settings:Message"]
            }, JsonRequestBehavior.AllowGet);
        }
    }
}