using Microsoft.AspNetCore.Mvc;
using MyDeal.TechTest.Services;
using MyDeal.TechTest.Models;
using System.Text.Json;

namespace MyDeal.TechTest.Controllers
{
    public class SettingsController : Controller
    {
        private IConfiguration _configuration;

        public SettingsController(IConfiguration iconfig)
        {
            _configuration = iconfig;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Json(new SettingsVm
            {
                User = UserService.GetUserDetails("2")?.Data,
                Message = _configuration.GetValue<string>("Settings:Message")
            }, new JsonSerializerOptions { PropertyNamingPolicy = null });
        }
    }
}