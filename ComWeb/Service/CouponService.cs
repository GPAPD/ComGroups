using ComWeb.Models;
using ComWeb.Service.IService;
using ComWeb.Utility;

namespace ComWeb.Service
{
	public class CouponService : ICouponService
	{
		private readonly IBaseService _baseService;
		public CouponService(IBaseService baseService) 
		{
			_baseService = baseService;
		}
		public async Task<ResponesDto?> CreateCouponAsync(CouponDto couponDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = couponDto,
				Url = SD.CouponAPIBase + "/api/coupon"
			});
		}

		public async Task<ResponesDto?> DeleteCouponAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.DELETE,
				Url = SD.CouponAPIBase + "/api/coupon/"+ id
			}); ;
		}

		public async Task<ResponesDto?> GetAllCouponAsync()
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.CouponAPIBase + "/api/coupon"
			});
		}

		public async Task<ResponesDto?> GetCouponAsync(string couponCode)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.CouponAPIBase + "/api/coupon/GetByCode/"+couponCode
			});
		}

		public async Task<ResponesDto?> GetCouponByIdAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.CouponAPIBase + "/api/coupon/" + id
			}); ;
		}

		public async Task<ResponesDto?> UpdateCouponAsync(CouponDto couponDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.PUT,
				Data = couponDto,
				Url = SD.CouponAPIBase + "/api/coupon"
			});
		}
	}
}
