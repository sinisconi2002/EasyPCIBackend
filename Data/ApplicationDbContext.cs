using EasyPCIBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyPCIBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<SSHConnection> SSHConnections { get; set; }
        public DbSet<Card> Cards { get; set; }
        //public DbSet<TestCase> TestCases { get; set; }   
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
    }
}
