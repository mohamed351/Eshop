using EShop.Core.Entities;

namespace EShop.API.DTOS
{
    public class ProductToReturnDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;


        public decimal Price { get; set; }

        public string PictureUrl { get; set; } = string.Empty;

        public string ProductType { get; set; } = string.Empty;

        public int ProductTypeId { get; set; }


        public string ProductBrand { get; set; } = string.Empty;


    }
   
}
