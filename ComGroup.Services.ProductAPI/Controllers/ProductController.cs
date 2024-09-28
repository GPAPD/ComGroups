
using AutoMapper;
using ComGroup.Services.ProductAPI.Model;
using ComGroup.Services.ProductAPI.Model.Dto;
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
        private readonly IMapper _mapper;

        public ProductController(AppDbContext db, IMapper mapper)
        {
            _responseDto = new ResponseDto();
            _db = db;
            _mapper = mapper;

        }


        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Product> obj = _db.Products.ToList();
                _responseDto.IsSuccess = true;
                _responseDto.Result = _mapper.Map<IEnumerable<ProductDto>>(obj);

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        [HttpGet]
        [Route("{Id:int}")]
        public ResponseDto Get(int Id)
        {
            try
            {
                Product obj = _db.Products.FirstOrDefault(a => a.ProductId == Id);
                _responseDto.IsSuccess = true;
                _responseDto.Result = _mapper.Map<ProductDto>(obj);

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        [HttpPost]
        public ResponseDto Save([FromBody] ProductDto product)
        {
            try
            {
                var obj = _mapper.Map<Product>(product);
                _db.Products.Add(obj);
                _db.SaveChanges();

                _responseDto.IsSuccess = true;
                _responseDto.Result = _mapper.Map<ProductDto>(obj);

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;

        }

        [HttpPut]
        public ResponseDto Update([FromBody] ProductDto product)
        {
            try
            {
                var obj = _mapper.Map<Product>(product);
                _db.Products.Add(obj);
                _db.SaveChanges();

                _responseDto.IsSuccess = true;
                _responseDto.Result = _mapper.Map<ProductDto>(obj);

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;

        }
    }
}
