using ComWeb.Models;

namespace ComWeb.Service.IService
{
    public interface IProductService
    {
        Task<ResponesDto?> GetAllProdoctsAsync();
        Task<ResponesDto?> GetProdoctByIdAsync(int Id);
        Task<ResponesDto?> UpdateProductAsync(ProductDto product);
        Task<ResponesDto?> CreateProductAsync(ProductDto product);
        Task<ResponesDto?> DeleteProductAsync(int Id);
    }
}
