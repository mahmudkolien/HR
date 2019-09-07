using System;
using System.ComponentModel.DataAnnotations.Schema;
using HR.Entities.Core;

namespace HR.Entities
{
    public class UserRolePermission : Entity
    {
        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public UserRole Role { get; set; }
        public string Permission { get; set; }
    }
}