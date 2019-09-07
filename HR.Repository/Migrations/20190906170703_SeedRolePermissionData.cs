using System;
using HR.Common;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Repository.Migrations
{
    public partial class SeedRolePermissionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed Role Permission
            migrationBuilder.Sql("INSERT INTO UserRolePermissions (Id,RoleId,Permission,IsDeleted)"+
                " VALUES ('"+Guid.NewGuid()+"',(SELECT Id FROM UserRoles WHERE RoleName = '"+
                DefaultValue.UserRoleName.SuperAdmin+"'),'Super_Admin','false')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM UserRolePermissions WHERE Permission = 'Super_Admin'");
        }
    }
}
