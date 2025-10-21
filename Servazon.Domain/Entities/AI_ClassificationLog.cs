using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Domain.Entities
{
    public class AI_ClassificationLog
    {
        public int Id { get; set; }
        public int RequestId { get; set; }           // FK → ServiceRequest.Id
        public string InputText { get; set; }
        public string PredictedCategory { get; set; }
        public decimal ConfidenceScore { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ServiceRequest Request { get; set; }
    }
}
