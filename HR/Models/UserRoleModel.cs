using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Models
{
    public class UserRoleModel
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public int? Status { get; set; }
    }
}