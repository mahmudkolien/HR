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
    }
}