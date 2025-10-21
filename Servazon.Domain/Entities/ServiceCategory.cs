using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Domain.Entities
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }

        // Navigation
        public ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}
