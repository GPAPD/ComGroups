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
                new SelectListItem{Text=SD.RoleCustomer,Value = SD.RoleCustomer}
            };
            ViewBag.rolelist = rolelist;

            return View();
        }
        [HttpPost]
        public async  Task<ActionResult> Register(RegistrationDto obj)
        {
            ResponesDto respose = await _authService.RegisterAsync(obj);
            ResponesDto assignRole;

            if (respose != null && respose.IsSuccess)
            {
                if (string.IsNullOrEmpty(obj.Role))
                {
                    obj.Role = SD.RoleCustomer;

                }

                assignRole = await _authService.AssignRoleAsync(obj);

                if (assignRole.IsSuccess)
                {
                    TempData["success"] = "Registration Successful";
                    return RedirectToAction(nameof(Login));
                }
            }
            else if (respose != null && !respose.IsSuccess)
            { 
                TempData["error"] = $"Registration Fail {respose.Message}";
            
            }
            var rolelist = new List<SelectListItem>
            {
                new SelectListItem{Text=SD.RoleAdmin,Value = SD.RoleAdmin},
                new SelectListItem{Text=SD.RoleCustomer,Value = SD.RoleCustomer}
            };
            ViewBag.rolelist = rolelist;

            return View(obj);
        }



        public ActionResult LogOut()
        {

            return View();
        }
    }
}
