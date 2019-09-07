using HR.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.Repository.Context
{
    public class HRDbContext : DbContext
    {
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRolePermission> UserRolePermissions { get; set; }

        public HRDbContext(DbContextOptions<HRDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
        }
    }
}