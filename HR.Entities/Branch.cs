using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR.Entities.Core;

namespace HR.Entities
{
    [Table("Branches")]
    public class Branch:AuditableEntity
    {
        public Guid CompanyId {get;set;}
        public string BranchName { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }
    }
}