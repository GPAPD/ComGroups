using ComWeb.Models;

namespace ComWeb.Service.IService
{
    public interface IProductService
    {
        Task<ResponesDto?> GetAllProdoctsAsync();
        Task<ResponesDto?> GetProdoctByIdAsync(int Id);
        Task<ResponesDto?> UpdateProductAsync();
        Task<ResponesDto?> CreateProductAsync();
        Task<ResponesDto?> DeleteProductAsync(int Id);
    }
}
