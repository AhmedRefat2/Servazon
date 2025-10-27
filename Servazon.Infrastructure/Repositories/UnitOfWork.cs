using Servazon.Domain.Interfaces.Repositories;
using Servazon.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ServazonDbContext _dbContext;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(ServazonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity);
            if(!_repositories.ContainsKey(type))
                _repositories[type] = new GenericRepository<TEntity>(_dbContext);

            return (IGenericRepository<TEntity>)_repositories[type];
        }

        public async Task<int> SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();
        public void Dispose()
            => _dbContext.Dispose();    
    }
}
