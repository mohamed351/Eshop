using EShop.Core.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Core.Specifications
{
    public class OrderWithItemAndOrderingSpecification:BaseSpecification<Order>
    {
        public OrderWithItemAndOrderingSpecification(string email)
            :base(o=> o.BuyerEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
            AddOrderByDesc(a => a.OrderDate);
        }
        public OrderWithItemAndOrderingSpecification(int Id, string email)
            :base(o=> o.ID == Id && o.BuyerEmail == email )
        {
            
        }
    }
}
