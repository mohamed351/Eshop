using EShop.Core.Entities;
using EShop.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext context;
        private Hashtable _repositories;
        public UnitOfWork(StoreDbContext context)
        {
            this.context = context;
        }
        public Task<int> Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }
    }
}
