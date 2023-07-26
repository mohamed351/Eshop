using EShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Core.Specifications
{
    public class ProductWithTypeAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductWithTypeAndBrandSpecification(ProductSpecParams productSpec)
            :base(x=> 
            string.IsNullOrEmpty(productSpec.Search) || x.Name.ToLower().Contains(productSpec.Search) &&
            (!productSpec.BrandID.HasValue || x.ProductBrandID == productSpec.BrandID)
            && !productSpec.TypeID.HasValue || x.ProductTypeId == productSpec.TypeID)
        {
            AddInclude(a => a.ProductBrand);
            AddInclude(a => a.ProductType);
            ApplyPaging((productSpec.PageSize * (productSpec.PageIndex - 1)), productSpec.PageSize);
       
            switch (productSpec.Sort)
            {
                case "priceAsc":
                    AddOrderBy(a => a.Price);
                    break;
                case "priceDesc":
                    AddOrderByDesc(a => a.Price);
                    break;
                
                default:
                    AddOrderBy(a => a.Name);
                    break;
            }
        }
        public ProductWithTypeAndBrandSpecification(int id)
            :base(a=> a.ID == id)
        {
            AddInclude(a => a.ProductBrand);
            AddInclude(a => a.ProductType);
        }
    }
}
