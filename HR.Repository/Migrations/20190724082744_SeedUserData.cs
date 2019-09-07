using System;
using HR.Common;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Repository.Migrations
{
    public partial class SeedUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed User Role 
            migrationBuilder.Sql("INSERT INTO UserRoles (Id,RoleName,Status,IsDeleted) VALUES ('"+Guid.NewGuid()+"','"+
                DefaultValue.UserRoleName.SuperAdmin+"','"+(int)EnumUserRoleStatus.SuperAdmin+"','false')");
            migrationBuilder.Sql("INSERT INTO UserRoles (Id,RoleName,Status,IsDeleted) VALUES ('"+Guid.NewGuid()+"','"+
                DefaultValue.UserRoleName.Admin+"','"+(int)EnumUserRoleStatus.GeneralUser+"','false')");

            // Seed User
            migrationBuilder.Sql("INSERT INTO Users (Id,FullName,UserName,Password,RoleId,Status,LockoutEnabled,IsDeleted)"+
                " VALUES ('"+Guid.NewGuid()+"','Administrator','admin','"+("12345").ToHash()+"',(SELECT Id FROM UserRoles WHERE RoleName = '"+
                DefaultValue.UserRoleName.SuperAdmin+"'),'"+(int)EnumUserRoleStatus.SuperAdmin+"','false','false')");
            migrationBuilder.Sql("INSERT INTO Users (Id,FullName,UserName,Password,RoleId,Status,LockoutEnabled,IsDeleted)"+
                " VALUES ('"+Guid.NewGuid()+"','Development','dev','"+("12345").ToHash()+"',(SELECT Id FROM UserRoles WHERE RoleName = '"+
                DefaultValue.UserRoleName.SuperAdmin+"'),'"+(int)EnumUserRoleStatus.SuperAdmin+"','false','false')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM UserRoles WHERE RoleName IN ('"+
                DefaultValue.UserRoleName.SuperAdmin+"','"+
                DefaultValue.UserRoleName.Admin+"')");
            migrationBuilder.Sql("DELETE FROM Users WHERE UserName IN ('admin','dev')");
        }
    }
}
