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
        public ProductWithTypeAndBrandSpecification()
        {
            AddInclude(a => a.ProductBrand);
            AddInclude(a => a.ProductType);
        }
        public ProductWithTypeAndBrandSpecification(int id)
            :base(a=> a.ID == id)
        {
            AddInclude(a => a.ProductBrand);
            AddInclude(a => a.ProductType);
        }
    }
}
