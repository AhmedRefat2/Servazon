using Servazon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Application.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IReadOnlyList<ServiceCategory>> GetAllAsync();
        Task<ServiceCategory?> GetByIdAsync(int id);
        Task<ServiceCategory> CreateAsync(ServiceCategory category);
        Task<bool> UpdateAsync(ServiceCategory category);
        Task<bool> DeleteAsync(int id);
    }
}
