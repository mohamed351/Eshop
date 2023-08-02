using EShop.Core.Entities;
using EShop.Core.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;

        public BasketRepository(IConnectionMultiplexer connectionMultiplexer)
        {
            this._database = connectionMultiplexer.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);

        }

        public async Task<CustomerBasket> UpdateBasetAsync(CustomerBasket customerBasket)
        {
          var created =   await _database.StringSetAsync(customerBasket.Id, JsonSerializer.Serialize(customerBasket),TimeSpan.FromDays(30));
            if (!created) return null;

            return await GetBasketAsync(customerBasket.Id);

        }
    }
}
