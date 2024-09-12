using ComWeb.Models;
using ComWeb.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;

namespace ComWeb.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService) 
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? couponList = new();

            ResponesDto? responesDto = await _couponService.GetAllCouponAsync();

            if (responesDto != null && responesDto.IsSuccess == true) 
            {
                couponList = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responesDto.Result));
            }

            return View(couponList);
        }
    }
}
