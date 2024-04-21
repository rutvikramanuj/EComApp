using ECom_MS.Services.CouponAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECom_MS.Services.CouponAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "ABC143",
                DiscountAmount =49.99,
                MinAmount = 1000 
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "Coupon10",
                DiscountAmount = 10,
                MinAmount = 200
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 3,
                CouponCode = "Coupon20",
                DiscountAmount = 20,
                MinAmount = 500
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
