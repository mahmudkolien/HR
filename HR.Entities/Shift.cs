using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR.Entities.Core;

namespace HR.Entities
{
    public class Shift : AuditableEntity
    {
        [Required]
        public string ShiftName { get; set; }
        [Required]
        public string ShiftCode { get; set; }
        public Guid ShiftTypeId { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
        public int? GraceTimeIn { get; set; }
        public int? GraceTimeOut { get; set; }
        public int? OvertimeStart { get; set; }

        [ForeignKey("ShiftTypeId")]
        public ShiftType ShiftType { get; set; }

    }
}