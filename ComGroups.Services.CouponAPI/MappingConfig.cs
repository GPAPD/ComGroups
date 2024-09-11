
using AutoMapper;
using ComGroups.Services.CouponAPI.Model;
using ComGroups.Services.CouponAPI.Model.Dto;

namespace ComGroups.Services.CouponAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps() 
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<CouponDto, Coupon>();
				config.CreateMap<Coupon, CouponDto>();
			});

			return mappingConfig;
		} 
	}
}
