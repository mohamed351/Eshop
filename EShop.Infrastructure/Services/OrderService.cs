using EShop.Core.Entities;
using EShop.Core.Entities.Orders;
using EShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        //private readonly IGenericRepository<DeliveryMethod> deliveryMethods;
        //private readonly IGenericRepository<Order> orders;
        //private readonly IGenericRepository<Product> productRepository;
        private readonly IBasketRepository basketRepository;
        private readonly IUnitOfWork work;

        public OrderService( IBasketRepository basketRepository, IUnitOfWork work)
        {
            //this.deliveryMethods = deliveryMethods;
            //this.orders = orders;
            //this.productRepository = productRepository;
            this.basketRepository = basketRepository;
            this.work = work;
        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, int DeliveryMethodId, string basketId, Address shippingAddress)
        {
            var basket = await basketRepository.GetBasketAsync(basketId);

            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await work.Repository<Product>().GetByIDAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.ID, productItem.Name, productItem.PictureUrl);

                var OrderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(OrderItem);

              
                   
            }
            var delivery = await work.Repository<DeliveryMethod>().GetByIDAsync(DeliveryMethodId);

            var subTotal = items.Sum(a => a.Price * a.Quantity);

            var order = new Order(buyerEmail, shippingAddress, delivery, items, subTotal);

            this.work.Repository<Order>().Add(order);
            var result = await this.work.Complete();


            return result <= 0 ? null: order;
            
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByID(int ID, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrderFromUserAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
