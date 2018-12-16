using System.Data.Entity;

namespace Call.Models
{
    public partial class IndexERPContext : DbContext
    {
        public IndexERPContext()
            : base("name=IndexDB_Connection")
        {
        }

        public DbSet<Flow> Flows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
