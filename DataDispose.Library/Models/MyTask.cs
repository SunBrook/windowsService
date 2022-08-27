using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataDispose.Library.Models
{
    public class MyTask
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("TASK_NO")]
        public string TaskNo { get; set; }

        [Column("INFORMATION")]
        public string Information { get; set; }

        [Column("DETAIL")]
        public string Detail { get; set; }

        [Column("STARTTIME")]
        public DateTime StartTime { get; set; }
    }

    public class TaskMap: EntityTypeConfiguration<MyTask>
    {
        public TaskMap()
        {
            this.HasKey(t => t.Id);
            this.ToTable("View_Task");
        }
    }
}
