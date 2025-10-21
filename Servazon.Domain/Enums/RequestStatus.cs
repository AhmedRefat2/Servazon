using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Domain.Enums
{
    public enum RequestStatus
    {
        Pending = 0,
        Assigned = 1,
        InProgress = 2,
        Completed = 3,
        Cancelled = 4
    }
}
