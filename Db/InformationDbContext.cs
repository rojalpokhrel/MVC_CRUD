using Microsoft.EntityFrameworkCore;
using ThisIsIt.Models;

namespace ThisIsIt.Db
{
    public class InformationDbContext : DbContext
    {
        public InformationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<MyCategory> Mycategorytable { get; set; }

    }
}
