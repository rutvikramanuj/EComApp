
using System.ComponentModel.DataAnnotations;

namespace EComApp.Web.Models
{
    public class CouponDto
    {
        public int couponId { get; set; }
        [Required(ErrorMessage ="Coupon Code is required")]
        public string couponCode { get; set; }
        [Required(ErrorMessage = "Discount Amount is required")]
        public double discountAmount { get; set; }
        [Required(ErrorMessage = "Min Amount is required")]
        public int minAmount { get; set; }
    }
}
