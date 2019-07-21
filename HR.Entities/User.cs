using System;
using HR.Entities.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Entities
{
    public class User : AuditableEntity
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string ImageFile { get; set; }
        public int? RoleId { get; set; }
        [ForeignKey("RoleId")]
        public UserRole UserRole { get; set; }
        [DataType(DataType.Password)]
        public string LastPassword { get; set; }
        [DataType(DataType.Date)]
        public DateTime? LastPassChangeDate { get; set; }
        public int? PasswordChangedCount { get; set; }
        public string SecurityStamp { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int? AccessFailedCount { get; set; }
        public int? Status { get; set; }
    }
}