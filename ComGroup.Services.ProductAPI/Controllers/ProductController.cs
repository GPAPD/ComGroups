
using ComGroups.Services.ProductAPI.Data;
using ComGroups.Services.ProductAPI.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ComGroup.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ResponseDto _responseDto;
        private readonly AppDbContext _db;
        public ProductController(AppDbContext db) 
        {
            _responseDto = new ResponseDto();
            _db = db;        
        }


        [HttpGet]
        public ResponseDto Get() 
        {
        
            return _responseDto;
        }
    }
}
