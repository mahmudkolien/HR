using System.Collections.Generic;

namespace HR.Models
{
    // public static class UserRolePermissionTaskModel
    // {
    //     public static IEnumerable<RolePermissionTask> RolePermissionTaskList => new List<RolePermissionTask> 
    //     {
    //         // User Configuration
    //         new RolePermissionTask { PermissionName = RolePermission.UserCreate, PermissionCategory = "User_Configuration" },
    //         new RolePermissionTask { PermissionName = RolePermission.UserEdit, PermissionCategory = "User_Configuration" },
    //         new RolePermissionTask { PermissionName = RolePermission.UserDelete, PermissionCategory = "User_Configuration" },
    //         new RolePermissionTask { PermissionName = RolePermission.UserView, PermissionCategory = "User_Configuration" },
            
    //         // User Role Configuration
    //         new RolePermissionTask { PermissionName = RolePermission.UserCreate, PermissionCategory = "User_Role_Configuration" },
    //         new RolePermissionTask { PermissionName = RolePermission.UserEdit, PermissionCategory = "User_Role_Configuration" },
    //         new RolePermissionTask { PermissionName = RolePermission.UserDelete, PermissionCategory = "User_Role_Configuration" },
    //         new RolePermissionTask { PermissionName = RolePermission.UserView, PermissionCategory = "User_Role_Configuration" },
    //     };
    // }

    public static class RolePermission 
    {
        // Super Admin
        public const string SuperAdmin = "Super_Admin";

        // User
        public const string UserCreate = "User_Create";
        public const string UserEdit = "User_Edit";
        public const string UserDelete = "User_Delete";
        public const string UserView = "User_View";
        
        // User Role
        public const string UserRoleCreate = "User_Role_Create";
        public const string UserRoleEdit = "User_Role_Edit";
        public const string UserRoleDelete = "User_Role_Delete";
        public const string UserRoleView = "User_Role_View";
    }

    // public class RolePermissionTask
    // {
    //     public string PermissionName { get; set; }
    //     public string PermissionCategory { get; set; }
    //     public bool IsChecked { get; set; }
    // }
}