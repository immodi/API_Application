using ApiApplication.APIs.DTOs;
using ApiApplication.Core.Models;
using AutoMapper;

namespace ApiApplication.APIs.Helpers
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
                return $"{_configuration["ApiBaseUrl"]}{source.ImageUrl}";

            return string.Empty;
        }
    }
}
