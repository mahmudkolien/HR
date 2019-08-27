using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR.Entities.Core;

namespace HR.Entities
{
    [Table("Departments")]
    public class Department:AuditableEntity
    {
        [Required]
        public string DepartmentName{ get;set;}
        public string Description { get; set; }
        [Required]
        public Guid BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
    }
}