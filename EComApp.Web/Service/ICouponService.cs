using EComApp.Web.Models;
using EComApp.Web.Models.Dtos;

namespace EComApp.Web.Service
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCoupons();
        Task<ResponseDto?> GetCouponById(int Id);
        Task<ResponseDto?> GetCouponByCode(string code);
        Task<ResponseDto?> Create(CouponDto couponDto);
        Task<ResponseDto?> Update(CouponDto couponDto);
        Task<ResponseDto?> Delete(int id);
    }
}
