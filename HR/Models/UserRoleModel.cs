using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR.Entities;

namespace HR.Models
{
    public class UserRoleModel
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public int? Status { get; set; }
        public IEnumerable<KeyValuePairModel> UserRolePermissions { get; set; }

        public UserRoleModel()
        {
            this.UserRolePermissions = new Collection<KeyValuePairModel>();
        }
    }
}