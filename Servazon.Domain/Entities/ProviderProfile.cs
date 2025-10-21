using Servazon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Domain.Entities
{
    public class ProviderProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;          // FK → ApplicationUser.Id
        public string Bio { get; set; } = null!;
        public int ExperienceYears { get; set; }
        public string WorkArea { get; set; } = null!;
        public decimal Rating { get; set; }
        public decimal Balance { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ApplicationUser User { get; set; } = null!;
        public ICollection<ServiceRequest> ServiceRequests { get; set; } = new HashSet<ServiceRequest>();
    }
}
