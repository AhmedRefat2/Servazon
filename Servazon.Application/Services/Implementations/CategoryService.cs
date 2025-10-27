using Servazon.Application.Services.Contracts;
using Servazon.Domain.Entities;
using Servazon.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Application.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<ServiceCategory>> GetAllAsync()
        {
            return await _unitOfWork.Repository<ServiceCategory>().GetAllAsync();
        }

        public async Task<ServiceCategory?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<ServiceCategory>().GetByIdAsync(id);
        }

        public async Task<ServiceCategory> CreateAsync(ServiceCategory category)
        {
            await _unitOfWork.Repository<ServiceCategory>().AddAsync(category);
            await _unitOfWork.SaveChangesAsync();
            return category;
        }

        public async Task<bool> UpdateAsync(ServiceCategory category)
        {
            _unitOfWork.Repository<ServiceCategory>().Update(category);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var repo = _unitOfWork.Repository<ServiceCategory>();
            var category = await repo.GetByIdAsync(id);
            if (category == null)
                return false;

            repo.Delete(category);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
