using EComApp.Web.Models;
using EComApp.Web.Models.Dtos;
using EComApp.Web.Utility;

namespace EComApp.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService baseService;

        public CouponService(IBaseService baseService)
        {
            this.baseService = baseService;
        }

        public async Task<ResponseDto?> Create(CouponDto couponDto)
        {
            RequestDto request = new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Url = SD.CouponApi + "/api/CouponAPI/Create",
                Data = couponDto
            };
           return await baseService.SendAsync(request);
        }

        public async Task<ResponseDto?> Delete(int id)
        {
            RequestDto request = new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponApi + "/api/CouponAPI/Delete/" + id,
            };
            return await baseService.SendAsync(request);
        }

        public async Task<ResponseDto?> GetCouponByCode(string code)
        {
            RequestDto request = new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponApi + "/api/CouponAPI/GetByCode/" + code,
            };
            return await baseService.SendAsync(request);
        }

        public async Task<ResponseDto?> GetCouponById(int Id)
        {
            RequestDto request = new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponApi + "/api/CouponAPI/" + Id,
            };
            return await baseService.SendAsync(request);
        }

        public async Task<ResponseDto?> GetCoupons()
        {
            RequestDto request = new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponApi + "/api/CouponAPI",
            };
            return await baseService.SendAsync(request);
        }

        public async Task<ResponseDto?> Update(CouponDto couponDto)
        {
            RequestDto request = new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.CouponApi + "/api/CouponAPI/Update",
                Data = couponDto
            };
            return await baseService.SendAsync(request);
        }
    }
}
