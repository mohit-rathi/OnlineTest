using Microsoft.EntityFrameworkCore;
using OnlineTest.Models;

namespace OnlineTest.Data
{
    public class OnlineTestContext : DbContext
    {
        public OnlineTestContext(DbContextOptions<OnlineTestContext> options) : base(options)
        { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}