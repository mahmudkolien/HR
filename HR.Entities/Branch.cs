using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR.Entities.Core;

namespace HR.Entities
{
    [Table("Branches")]
    public class Branch:AuditableEntity
    {
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string PostCode { get; set; }

        [Required]
        public Guid CompanyId {get;set;}
         [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        
        public Guid? CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        public Guid? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

    }
}