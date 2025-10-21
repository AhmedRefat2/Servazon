using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ProviderProfile? ProviderProfile { get; set; }
        public ICollection<ServiceRequest> ClientRequests { get; set; } = new HashSet<ServiceRequest>();
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
    }
}
