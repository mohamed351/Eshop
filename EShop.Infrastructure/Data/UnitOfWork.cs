﻿using EShop.Core.Entities;
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
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if(_repositories == null)
            {
                _repositories = new Hashtable();
               
            }

            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)),this.context);
                _repositories.Add(type,repositoryInstance);

            }
            return (IGenericRepository<TEntity>)_repositories[type];
        }
        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }

       
    }
}
