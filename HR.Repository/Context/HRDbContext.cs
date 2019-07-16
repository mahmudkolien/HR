using Microsoft.EntityFrameworkCore;

namespace HR.Repository.Context
{
    public class HRDbContext : DbContext
    {
        public HRDbContext(DbContextOptions<HRDbContext> options) : base(options)
        {
        }
    }
}