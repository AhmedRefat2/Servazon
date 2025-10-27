using Servazon.Application.Services.Contracts;
using Servazon.Domain.Entities;
using Servazon.Domain.Enums;
using Servazon.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Application.Services.Implementations
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceRequest> CreateAsync(ServiceRequest serviceRequest)
        {
            await _unitOfWork.Repository<ServiceRequest>().AddAsync(serviceRequest);
            await _unitOfWork.SaveChangesAsync();
            return serviceRequest;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var repository = _unitOfWork.Repository<ServiceRequest>();
            var serviceRequest = await repository.GetByIdAsync(id);
            if (serviceRequest == null)
                return false;
            repository.Delete(serviceRequest);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public Task<IReadOnlyList<ServiceRequest>> GetAllAsync()
            => _unitOfWork.Repository<ServiceRequest>().GetAllAsync();    

        public Task<ServiceRequest?> GetByIdAsync(int id)
            => _unitOfWork.Repository<ServiceRequest>().GetByIdAsync(id);

        public async Task<bool> UpdateAsync(ServiceRequest request)
        {
            _unitOfWork.Repository<ServiceRequest>().Update(request);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStatusAsync(int id, RequestStatus status)
        {
            var repository = _unitOfWork.Repository<ServiceRequest>();
            var serviceRequest = await repository.GetByIdAsync(id);

            if (serviceRequest == null) 
                return false;

            serviceRequest.Status = status;

            if(status == RequestStatus.Completed)
            {
                serviceRequest.CompletedAt = DateTime.UtcNow;
                // You can Add Notification Logic Here Or payment here 
            }

            repository.Update(serviceRequest);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
