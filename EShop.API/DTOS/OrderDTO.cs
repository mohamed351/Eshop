namespace EShop.API.DTOS
{
    public class OrderDTO
    {
        public string BasetID { get; set; }

        public int DeliveyMethod { get; set; }

        public AddressDTO ShiptoAddress { get; set; }


    }
}
