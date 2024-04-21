using EComApp.Web.Models;
using EComApp.Web.Models.Dtos;
using EComApp.Web.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EComApp.Web.Controllers
{
    public class CouponController : Controller
    {
        public CouponController(ICouponService couponService)
        {
            CouponService = couponService;
        }

        public ICouponService CouponService { get; }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto> list = new();
            ResponseDto response  = await CouponService.GetCoupons();
            if (response != null && response.isSuccess)
            {
               
                if (response.isSuccess)
                {
                    TempData["success"] = response.message;
                }
                list = JsonSerializer.Deserialize<List<CouponDto>>(Convert.ToString(response.result));
            }
            if (response.isError)
            {
                TempData["error"] = response.message;
            }
            return View(list);
        }

        public async Task<IActionResult> CreateCoupon()
        {
            return View();
        }

        public async Task<IActionResult> CreateNewCoupon(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto response = await CouponService.Create(model);
                if (response.isError)
                {
                    TempData["error"] = response.message;
                }
                if (response.isSuccess)
                {
                    TempData["success"] = response.message;
                }
            }
            return RedirectToAction("CouponIndex");
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto response = await CouponService.Delete(id);
            if (response.isError)
            {
                TempData["error"] = response.message;
            }
            if (response.isSuccess)
            {
                TempData["success"] = response.message;
            return RedirectToAction("CouponIndex");
            }
            else
            {
                return null;
            }

        }
    }
}
