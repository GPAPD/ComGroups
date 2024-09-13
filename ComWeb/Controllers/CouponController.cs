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
            else 
            {
                TempData["error"] = responesDto?.Message;
            }

            return View(couponList);
        }

        public async Task<IActionResult> CouponCreate() 
        {
        
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto model)
        {
            if (ModelState.IsValid) 
            {
                ResponesDto? responesDto = await _couponService.CreateCouponAsync(model);

                if (responesDto != null && responesDto.IsSuccess == true)
                {
                    TempData["success"] = "Coupon Created Successfully";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = responesDto?.Message;
                }
            }
            return View(model);
        }

		public async Task<IActionResult> CouponDelete(int couponId)
		{

			ResponesDto? responesDto = await _couponService.GetCouponByIdAsync(couponId);

			if (responesDto != null && responesDto.IsSuccess == true)
			{
				CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(responesDto.Result));
                return View(model);
			}
            else
            {
                TempData["error"] = responesDto?.Message;
            }

            return NotFound();
		}

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto couponDto)
        {

            ResponesDto? responesDto = await _couponService.DeleteCouponAsync(couponDto.CouponId);

            if (responesDto != null && responesDto.IsSuccess == true)
            {
                TempData["success"] = "Coupon Deleted Successfully";
                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = responesDto?.Message;
            }

            return View(couponDto);
        }
    }
}
