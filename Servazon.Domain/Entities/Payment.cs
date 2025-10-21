using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int RequestId { get; set; }           // FK → ServiceRequest.Id
        public decimal Amount { get; set; }
        public string Method { get; set; }           // e.g., Cash / Card
        public string Status { get; set; }           // Paid / Pending / Failed
        public string TransactionId { get; set; }
        public DateTime PaidAt { get; set; }

        // Navigation
        public ServiceRequest Request { get; set; }
    }
}
