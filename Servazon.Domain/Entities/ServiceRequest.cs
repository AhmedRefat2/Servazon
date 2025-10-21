using Servazon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Domain.Entities
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public string ClientId { get; set; }         // FK → ApplicationUser.Id
        public int? ProviderId { get; set; }         // FK → ProviderProfile.Id
        public int CategoryId { get; set; }          // FK → ServiceCategory.Id

        public string Description { get; set; }
        public decimal? Price { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ScheduledFor { get; set; }
        public DateTime? CompletedAt { get; set; }

        // Navigation
        public ApplicationUser Client { get; set; }
        public ProviderProfile Provider { get; set; }
        public ServiceCategory Category { get; set; }
        public Feedback Feedback { get; set; }
        public Payment Payment { get; set; }
        public AI_ClassificationLog AI_ClassificationLog { get; set; }
    }
}
