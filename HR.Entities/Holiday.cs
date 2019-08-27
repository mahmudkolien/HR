using System;
using HR.Entities.Core;

namespace HR.Entities
{
    public class Holiday : AuditableEntity
    {
        public string HolidayTitle { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}