using Microsoft.AspNetCore.Mvc;
using MyDeal.TechTest.Services;
using MyDeal.TechTest.Models;


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