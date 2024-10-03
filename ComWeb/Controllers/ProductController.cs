using ComWeb.Models;
using ComWeb.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ComWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> ProductIndex()
        {
            List <ProductDto> productList = new();

            ResponesDto dto = await _productService.GetAllProdoctsAsync();
            if (dto != null && dto.IsSuccess == true) 
            {
                productList = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(dto.Result));
            
            }
            else 
            {
            
            }


            return View(productList);
        }
    }
}
