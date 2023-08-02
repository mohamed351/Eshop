﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Core.Entities
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
            
        }
        public CustomerBasket(string id)
        {
            this.Id = id;
        }
        public string Id { get; set; }
        public List<BasketItem> Items { get; set; }

    }
}
