using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable  
    {
        // Signuture for Repositories 
        // Follow Open Closed Principle
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
