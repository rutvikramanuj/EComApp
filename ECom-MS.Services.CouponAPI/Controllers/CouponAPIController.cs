using AutoMapper;
using ECom_MS.Services.CouponAPI.Data;
using ECom_MS.Services.CouponAPI.Entities;
using ECom_MS.Services.CouponAPI.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECom_MS.Services.CouponAPI.Controllers
{
    [Route("api/CouponAPI")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        public DataContext _context { get; }
        private ResponseDto _responseDto;
        private IMapper _mapper;
        public CouponAPIController(DataContext context,IMapper mapper)
        {
            _context = context;
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable < Coupon > couponList = await _context.Coupons.ToListAsync();
                _responseDto.IsSuccess = true;
                _responseDto.Message = "sucessfull";
                _responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(couponList); ;
                return _responseDto;
            }
            catch (Exception err)
            {
                _responseDto.Message = err.Message;
                _responseDto.IsSuccess = false;
                _responseDto.IsError = true;
                return _responseDto;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                Coupon coupon = await _context.Coupons.FirstAsync(coupon => coupon.CouponId == id);
                

                _responseDto.IsSuccess = true;
                _responseDto.Message = "sucessfull";
                _responseDto.Result = _mapper.Map<CouponDto>(coupon);
                return _responseDto;
            }
            catch (Exception err)
            {
                _responseDto.Message = err.Message;
                _responseDto.IsSuccess = false;
                _responseDto.IsError = true;
                return _responseDto;
            }
        }


        [HttpGet]
        [Route("GetByCode/{code}")]
        public async Task<ResponseDto> GetByCode(string code)
        {
            try
            {
                Coupon coupon = await _context.Coupons.FirstAsync(coupon => coupon.CouponCode == code);


                _responseDto.IsSuccess = true;
                _responseDto.Message = "sucessfull";
                _responseDto.Result = _mapper.Map<CouponDto>(coupon);
                return _responseDto;
            }
            catch (Exception err)
            {
                _responseDto.Message = err.Message;
                _responseDto.IsSuccess = false;
                _responseDto.IsError = true;
                return _responseDto;
            }
        }




        [HttpPost]
        [Route("Create")]
        public async Task<ResponseDto> Create([FromBody] CouponDto request)
        {
            try
            {
                Coupon coupon = _mapper.Map<Coupon>(request);
                await _context.Coupons.AddAsync(coupon);
                await _context.SaveChangesAsync();
                _responseDto.IsSuccess = true;
                _responseDto.Message = "sucessfull";
                _responseDto.Result = coupon;
                return _responseDto;
            }
            catch (Exception err)
            {
                _responseDto.Message = err.Message;
                _responseDto.IsSuccess = false;
                _responseDto.IsError = true;
                return _responseDto;
            }
        }


        [HttpPut]
        [Route("Update")]
        public async Task<ResponseDto> Update([FromBody] CouponDto request)
        {
            try
            {
                Coupon coupon = _mapper.Map<Coupon>(request);
                 _context.Coupons.Update(coupon);
                await _context.SaveChangesAsync();
                _responseDto.IsSuccess = true;
                _responseDto.Message = "sucessfull";
                _responseDto.Result = coupon;
                return _responseDto;
            }
            catch (Exception err)
            {
                _responseDto.Message = err.Message;
                _responseDto.IsSuccess = false;
                _responseDto.IsError = true;
                return _responseDto;
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                Coupon coupon = await _context.Coupons.FirstAsync(coupon => coupon.CouponId == id);
                _context.Coupons.Remove(coupon);
                await _context.SaveChangesAsync();
                _responseDto.IsSuccess = true;
                _responseDto.Message = "sucessfull";
                _responseDto.Result = coupon;
                return _responseDto;
            }
            catch (Exception err)
            {
                _responseDto.Message = err.Message;
                _responseDto.IsSuccess = false;
                _responseDto.IsError = true;
                return _responseDto;
            }
        }
    }
}
