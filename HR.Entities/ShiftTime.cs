using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR.Entities.Core;

namespace HR.Entities
{
    public class ShiftTime : AuditableEntity
    {
        [Required]
        public Guid ShiftId { get; set; }
        public DayOfWeek? Day { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? From { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? To { get; set; }

        [ForeignKey("ShiftId")]
        public Shift Shift { get; set; }
    }
}