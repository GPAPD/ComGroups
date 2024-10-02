using ComWeb.Models;
using ComWeb.Service.IService;
using ComWeb.Utility;

namespace ComWeb.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;

        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponesDto?> CreateProductAsync(ProductDto product)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = product,
                Url = SD.ProductAPIBase + "/api/product"
            });
        }

        public async Task<ResponesDto?> DeleteProductAsync(int Id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/product/"+ Id
            });
        }

        public async Task<ResponesDto?> GetAllProdoctsAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/product/"
            });
        }

        public async Task<ResponesDto?> GetProdoctByIdAsync(int Id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/product/" + Id
            });
        }

        public async Task<ResponesDto?> UpdateProductAsync(ProductDto product)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Data = product,
                Url = SD.ProductAPIBase + "/api/product/"
            });
        }
    }
}
