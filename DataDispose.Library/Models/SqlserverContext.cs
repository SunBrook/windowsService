using System.Data.Entity;

namespace DataDispose.Library.Models
{
    public class SqlserverContext : DbContext
    {
        public SqlserverContext() : base("name=sqlServerConn")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TaskMap());
        }

        public DbSet<MyTask> Tasks { get; set; }
    }
}
