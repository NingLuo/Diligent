using System.Data.Entity.ModelConfiguration;
using Diligent.BOL;

namespace Diligent.DAL.EntityCongfigurations
{
    public class TaskConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskConfiguration()
        {
            ToTable("Task");

            Property(t => t.Description)
            .HasMaxLength(2000);

            Property(t => t.Subject)
            .IsRequired()
            .HasMaxLength(255);

            HasRequired(t => t.Project)
            .WithMany(c => c.Tasks)
            .HasForeignKey(t => t.ProjectId);

            HasMany(t => t.ReviewMissions)
            .WithRequired(rm => rm.Task)
            .HasForeignKey(rm => rm.TaskId);

            HasRequired(t => t.Status)
            .WithMany()
            .HasForeignKey(t => t.StatusId)
            .WillCascadeOnDelete(false);
        }
    }
}
