using ComWeb.Models;
using ComWeb.Service.IService;
using ComWeb.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComWeb.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) 
        {
            _authService = authService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            LogInRequestDto logInRequestDto = new LogInRequestDto();

            return View(logInRequestDto);
        }

        [HttpGet]
        public ActionResult Register()
        {
            var rolelist = new List<SelectListItem>
            {
                new SelectListItem{Text=SD.RoleAdmin,Value = SD.RoleAdmin},
                new SelectListItem{Text=SD.Customer,Value = SD.Customer}
            };
            ViewBag.rolelist = rolelist;

            return View();
        }


        public ActionResult LogOut()
        {

            return View();
        }
    }
}
