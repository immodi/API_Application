using ApiApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiApplication.Core.Specifications
{
    public class ProductWithFilterForCountSpecification : BaseSepcification<Product>
    {
        public ProductWithFilterForCountSpecification(ProductSpecParams productSpec):base(p =>
            (string.IsNullOrEmpty(productSpec.Search) || p.Name.ToLower().Contains(productSpec.Search.ToLower()))
            &&
            (!productSpec.BrandId.HasValue || p.ProductBrandId == productSpec.BrandId)
            &&
            (!productSpec.TypeId.HasValue || p.ProductTypeId== productSpec.TypeId)
        )
        {

        }
    }
}
