using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Domain.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public int RequestId { get; set; }           // FK → ServiceRequest.Id
        public string ClientId { get; set; }         // FK → ApplicationUser.Id
        public int Rating { get; set; }              // 1 to 5
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ServiceRequest Request { get; set; }
        public ApplicationUser Client { get; set; }
    }
}
