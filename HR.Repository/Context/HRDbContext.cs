using HR.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.Repository.Context
{
    public class HRDbContext : DbContext
    {
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments{get;set;}
        public DbSet<Company> Companies{get;set;}
        public DbSet<Branch> Branches{get;set;}
        public HRDbContext(DbContextOptions<HRDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
        }
    }
}