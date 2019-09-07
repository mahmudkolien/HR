using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR.Entities;

namespace HR.Models
{
    public class SaveUserRoleModel
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<string> UserRolePermissions { get; set; }

        public SaveUserRoleModel()
        {
            this.UserRolePermissions = new Collection<string>();
        }
    }
}