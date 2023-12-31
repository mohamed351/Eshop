﻿using EShop.Core.Entities;
using EShop.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Core.Interfaces
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        Task<T> GetByIDAsync(int ID);
        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetEntityWithSpec(ISpecification<T> specification);
        Task<IReadOnlyList<T>> ListAllAsync(ISpecification<T> specification);
        Task<int> CountAsync(ISpecification<T> specification);

        void Add(T Entity);
        void Update(T Entity);

        void Delete(T Entity);

    }
}
