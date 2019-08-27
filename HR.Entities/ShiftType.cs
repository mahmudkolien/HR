using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HR.Entities.Core;

namespace HR.Entities
{
    public class ShiftType : AuditableEntity
    {
        [Required]
        public string TypeName { get; set; }

    }
}