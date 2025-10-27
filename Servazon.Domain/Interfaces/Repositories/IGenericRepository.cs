﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        // Signuture For Methods 
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity); 
        void Update(T entity);
        void Delete(T entity);
    }
}
