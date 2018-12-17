namespace Call
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Call.Models;

    public partial class IndexERPContext : DbContext
    {
        public IndexERPContext()
            : base("name=IndexDB_Connection")
        {
        }

        public DbSet<Flow> Flows { get; set; }
        public DbSet<WorkFlow> WorkFlows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
