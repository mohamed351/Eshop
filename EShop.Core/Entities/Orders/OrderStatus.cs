using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EShop.Core.Entities.Orders
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending=0,
        [EnumMember(Value = "Payment Recived")]
        PaymentRecived = 1,
        [EnumMember(Value = "Payment Faild")]
        PaymentFaild =2

    }
}
