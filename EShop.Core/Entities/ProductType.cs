using System.Collections.Generic;

namespace EShop.Core.Entities
{
    public class ProductType:BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}