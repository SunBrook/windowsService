using SQLite.CodeFirst;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite.EF6;


namespace DataDispose.Library.Models
{
    public class SqliteContext : DbContext
    {
        static string dbPath = $@"Data Source={AppDomain.CurrentDomain.BaseDirectory}\\tasks.db";

        public static SqliteContext Instance
        {
            get
            {
                DbConnection sqliteCon = SQLiteProviderFactory.Instance.CreateConnection();
                sqliteCon.ConnectionString = dbPath;
                return new SqliteContext(sqliteCon);
            }
        }

        private SqliteContext(DbConnection con) : base(con, true) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var table = modelBuilder.Entity<MyTask>().ToTable("MyTask");
            table.HasKey(c => c.Id);
            table.HasIndex(c => c.TaskNo);
            table.HasIndex(c => c.StartTime);
            Database.SetInitializer(new SqliteCreateDatabaseIfNotExists<SqliteContext>(modelBuilder));
        }

        public DbSet<MyTask> LocalTasks { get; set; }
    }
}
