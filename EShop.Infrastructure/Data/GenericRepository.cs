﻿using EShop.Core.Entities;
using EShop.Core.Interfaces;
using EShop.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreDbContext context;

        public GenericRepository(StoreDbContext context)
        {
            this.context = context;
        }
        public async Task<T> GetByIDAsync(int ID)
        {
            return await this.context.Set<T>().FindAsync(ID);
        }

    
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await this.context.Set<T>().ToListAsync();
        }
        public async Task<T> GetEntityWithSpec(ISpecification<T> specification)
        {
            return await this.ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(ISpecification<T> specification)
        {
            return await this.ApplySpecification(specification).ToListAsync();
        }
      

        public async Task<int> CountAsync(ISpecification<T> specification)
        {
            return await this.ApplySpecification(specification).CountAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(this.context.Set<T>().AsQueryable(), specification);
        }

        public void Add(T Entity)
        {
             this.context.Set<T>().Add(Entity);
        }

        public void Update(T Entity)
        {
            this.context.Set<T>().Attach(Entity);
            context.Entry(Entity).State = EntityState.Modified;
        }

        public void Delete(T Entity)
        {
            context.Set<T>().Remove(Entity);
        }
    }
}
