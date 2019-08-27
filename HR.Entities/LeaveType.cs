using System.ComponentModel.DataAnnotations;
using HR.Entities.Core;

namespace HR.Entities
{
    public class LeaveType : AuditableEntity
    {
        [Required]
        public string TypeName { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
    }
}