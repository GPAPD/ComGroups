using ComWeb.Models;

namespace ComWeb.Service.IService
{
	public interface ICouponService
	{
		Task<ResponesDto?> GetCouponAsync(string couponCode);
		Task<ResponesDto?> GetAllCouponAsync();
		Task<ResponesDto?> GetCouponByIdAsync(int id);
		Task<ResponesDto?> CreateCouponAsync(CouponDto couponDto);
		Task<ResponesDto?> UpdateCouponAsync(CouponDto couponDto);
		Task<ResponesDto?> DeleteCouponAsync(int id);
	}
}
