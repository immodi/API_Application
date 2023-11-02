using ApiApplication.APIs.DTOs;
using ApiApplication.Core.Models;
using AutoMapper;

namespace ApiApplication.APIs.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                     .ForMember(pd => pd.ProductBrand, o => o.MapFrom(p => p.ProductBrand.Name))
                     .ForMember(pd => pd.ProductType, o => o.MapFrom(p => p.ProductType.Name))
                     .ForMember(pd => pd.ImageUrl, o => o.MapFrom<ProductPictureUrlResolver>());
        }
    }
}
