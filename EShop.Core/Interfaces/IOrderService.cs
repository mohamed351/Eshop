using EShop.Core.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Core.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string buyerEmail, int DeliveryMethod, string basketId, Address shippingAddress);
        Task<IReadOnlyList<Order>> GetOrderFromUserAsync(string buyerEmail);

        Task<Order> GetOrderByID(int ID, string buyerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();


    }
}
