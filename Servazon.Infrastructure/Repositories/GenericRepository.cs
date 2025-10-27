using Microsoft.EntityFrameworkCore;
using Servazon.Domain.Interfaces.Repositories;
using Servazon.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ServazonDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ServazonDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
            => await _dbSet.AsNoTracking().ToListAsync();
        public async Task<T?> GetByIdAsync(int id)
            => await _dbSet.FindAsync(id);


        public async Task AddAsync(T entity)
            => await _dbSet.AddAsync(entity);
        public void Delete(T entity)
            => _dbSet.Remove(entity);
        public void Update(T entity)
            => _dbSet.Update(entity);
    }
}
