using HouseasyModel;
using Microsoft.EntityFrameworkCore;

namespace HouseasyInfra.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null;
    }
}
