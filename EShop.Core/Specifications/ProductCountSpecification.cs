using EShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Core.Specifications
{
    public class ProductCountSpecification:BaseSpecification<Product>
    {
        public ProductCountSpecification(ProductSpecParams productSpec)
         : base(x =>
          string.IsNullOrEmpty(productSpec.Search) || x.Name.ToLower().Contains(productSpec.Search) &&
            (!productSpec.BrandID.HasValue || x.ProductBrandID == productSpec.BrandID)
            && !productSpec.TypeID.HasValue || x.ProductTypeId == productSpec.TypeID)
        {
            
        }

    }
}
