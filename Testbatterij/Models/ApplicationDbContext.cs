using System.Data.Entity;

namespace Testbatterij.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TestScenario> TestScenarios { get; set; }
        public DbSet<TestSet> TestSets { get; set; }
        public DbSet<TestSetTestScenarios> TestSetTestScenarios { get; set; }
    }
}