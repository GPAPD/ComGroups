﻿
using AutoMapper;
using ComGroup.Services.ProductAPI.Model;
using ComGroup.Services.ProductAPI.Model.Dto;

namespace ComGroups.Services.ProductAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps() 
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<ProductDto, Product>();
				config.CreateMap<Product, ProductDto>();
			});

			return mappingConfig;
		} 
	}
}
