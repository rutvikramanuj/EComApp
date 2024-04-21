using AutoMapper;
using ECom_MS.Services.CouponAPI.Entities;
using ECom_MS.Services.CouponAPI.Models.Dtos;

namespace ECom_MS.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => 
            {
                config.CreateMap<CouponDto, Coupon>(); 
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }
}
