
using System.ComponentModel.DataAnnotations;
using HR.Entities.Core;

namespace HR.Entities
{
    public class Country:AuditableEntity
    {
        [Required]
        public string CountryCode{ get;set;}
        [Required]
        public string CountryName{ get;set;}
    }
}