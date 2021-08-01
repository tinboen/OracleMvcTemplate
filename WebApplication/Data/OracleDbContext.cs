using Microsoft.EntityFrameworkCore;
using OracleMvcTemplate.Models;

namespace OracleMvcTemplate.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options)
          : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
