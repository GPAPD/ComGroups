using AutoMapper;
using ComGroups.Services.CouponAPI.Data;
using ComGroups.Services.CouponAPI.Model;
using ComGroups.Services.CouponAPI.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComGroups.Services.CouponAPI.Controllers
{
	[Route("api/coupon")]
	[ApiController]
	public class CouponApiController : ControllerBase
	{
		private readonly AppDbContext _db;
		private ResponseDto _responseDto;
		private IMapper _mapper;

		public CouponApiController(AppDbContext db,IMapper mapper)
		{
			_db = db;
			_responseDto = new ResponseDto();
			_mapper = mapper;
		}

		[HttpGet]
		public ResponseDto Get()
		{
			try
			{
				IEnumerable<Coupon> objList = _db.Coupons.ToList();
				_responseDto.IsSuccess = true;
				_responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
			}
			catch (Exception ex)
			{
				_responseDto.IsSuccess=false;
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
				Coupon obj = _db.Coupons.First(a => a.CouponId == Id);
				_mapper.Map<CouponDto>(obj);
				_responseDto.Result = _mapper.Map<CouponDto>(obj);
				_responseDto.IsSuccess = true;
			}
			catch (Exception ex)
			{
				_responseDto.IsSuccess=false;
				_responseDto.Message = ex.Message;

			}
			return _responseDto;
		}

		[HttpGet]
		[Route("GetByCode/{code}")]
		public ResponseDto GetByCode(string code)
		{
			try
			{
				Coupon obj = _db.Coupons.FirstOrDefault(a => a.CouponCode == code);
				if (obj == null) 
				{
					_responseDto.IsSuccess = false;
					return _responseDto;
				}
				_responseDto.IsSuccess = true;
				_responseDto.Result = _mapper.Map<CouponDto>(obj);
			}
			catch (Exception ex)
			{
				_responseDto.IsSuccess = false;
				_responseDto.Message = ex.Message;

			}
			return _responseDto;
		}


		[HttpPost]
		public ResponseDto Save([FromBody] CouponDto couponDto)
		{
			try
			{
				Coupon obj = _mapper.Map<Coupon>(couponDto);
				_db.Coupons.Add(obj);
				_responseDto.IsSuccess = true;
				_db.SaveChanges();
				_responseDto.Result = _mapper.Map<CouponDto>(obj);
			}
			catch (Exception ex)
			{
				_responseDto.IsSuccess = false;
				_responseDto.Message = ex.Message;

			}
			return _responseDto;
		}

		[HttpPut]
		public ResponseDto Update([FromBody] CouponDto couponDto)
		{
			try
			{
				Coupon obj = _mapper.Map<Coupon>(couponDto);
				_db.Coupons.Update(obj);
				_responseDto.IsSuccess = true;
				_db.SaveChanges();
				_responseDto.Result = _mapper.Map<CouponDto>(obj);


				
			}
			catch (Exception ex)
			{
				_responseDto.IsSuccess = false;
				_responseDto.Message = ex.Message;

			}
			return _responseDto;
		}

		[HttpDelete]
        [Route("{Id:int}")]
        public ResponseDto Delete(int Id)
		{
			try
			{
				Coupon obj = _db.Coupons.First(u=>u.CouponId == Id);
				_db.Coupons.Remove(obj);
				_responseDto.IsSuccess = true;
				_db.SaveChanges();

				_responseDto.Result = _mapper.Map<CouponDto>(obj);
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
