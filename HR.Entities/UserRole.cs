using HR.Entities.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR.Entities
{
    public class UserRole : AuditableEntity
    {
        [Required]
        public string RoleName { get; set; }
        public int? Status { get; set; }
        public ICollection<UserRolePermission> UserRolePermissions { get; set; }
    }
}