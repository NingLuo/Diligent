using System.Data.Entity.ModelConfiguration;
using Diligent.BOL;

namespace Diligent.DAL.EntityCongfigurations
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            ToTable("Project");

            Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);

            HasRequired(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserId);
        }
    }
}
