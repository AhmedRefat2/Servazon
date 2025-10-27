using Servazon.Domain.Entities;
using Servazon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Application.Services.Contracts
{
    public interface IServiceRequestService
    {
        Task<IReadOnlyList<ServiceRequest>> GetAllAsync();
        Task<ServiceRequest?> GetByIdAsync(int id);
        Task<ServiceRequest> CreateAsync(ServiceRequest serviceRequest);
        Task<bool> UpdateAsync(ServiceRequest request);
        Task<bool> DeleteAsync(int id);
        // For updating only the status of a service request and doing specif actions 
        Task<bool> UpdateStatusAsync(int id, RequestStatus status);
    }
}
