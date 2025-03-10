using Microsoft.EntityFrameworkCore;
using SatbayevUsers.Models;

namespace SatbayevUsers.Data
{
    public class SatbayevUsersContext : DbContext
    {
        public SatbayevUsersContext(DbContextOptions<SatbayevUsersContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = null!;
    }

}