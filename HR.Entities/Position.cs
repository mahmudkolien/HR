using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR.Entities.Core;

namespace HR.Entities
{
    public class Position : AuditableEntity
    {
        [Required]
        public string PositionName { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }
        public Guid? ReportingPositionId { get; set; }

        
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        [ForeignKey("ReportingPositionId")]
        public Position ReportingPosition { get; set; }
    }
}