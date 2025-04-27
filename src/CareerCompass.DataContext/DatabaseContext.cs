using CareerCompass.DataContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareerCompass.DataContext
{
    public class DatabaseContext
        : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<SchoolYear> SchoolYears { get; set; }

        public DbSet<UserExport> UserExports { get; set; }
    }
}
