using Microsoft.AspNetCore.Mvc;
using MyDeal.TechTest.Services;
using MyDeal.TechTest.Models;
using System.Text.Json;

namespace MyDeal.TechTest.Controllers
{
    public class SettingsController : Controller
    {
        private IConfiguration _configuration;
        private IUserService _userService;

        public SettingsController(IConfiguration iconfig, IUserService userService)
        {
            _configuration = iconfig;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var userResponse = await _userService.GetUserDetails("2");

            return Json(new SettingsVm
            {
                User = userResponse?.Data,
                Message = _configuration.GetValue<string>("Settings:Message")
            }, new JsonSerializerOptions { PropertyNamingPolicy = null });
        }
    }
}