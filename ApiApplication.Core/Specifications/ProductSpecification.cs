using ApiApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiApplication.Core.Specifications
{
    public class ProductSpecifications : BaseSepcification<Product>
    {
        public ProductSpecifications(ProductSpecParams productSpec):base(p => 
            (string.IsNullOrEmpty(productSpec.Search) || p.Name.ToLower().Contains(productSpec.Search.ToLower()))
            &&
            (!productSpec.BrandId.HasValue || p.ProductBrandId == productSpec.BrandId)
            &&
            (!productSpec.TypeId.HasValue || p.ProductTypeId== productSpec.TypeId)
        )
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);

            if (!string.IsNullOrEmpty(productSpec.Sort))
            {
                switch (productSpec.Sort)
                {
                    case "PriceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "PriceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }

            ApplyPagination(productSpec.PageSize * (productSpec.PageIndex - 1), productSpec.PageSize);
        }

        public ProductSpecifications(int id):base(p => p.Id == id)
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
        }
    }
}
