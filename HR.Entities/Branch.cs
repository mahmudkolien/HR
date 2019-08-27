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
         [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string PhoneNo{get;set;}
        public string Email{get;set;}
        
       
    }
}