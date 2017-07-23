using System.Data.Entity.ModelConfiguration;
using Diligent.BOL;

namespace Diligent.DAL.EntityCongfigurations
{
    public class StatusConfiguration : EntityTypeConfiguration<Status>
    {
        public StatusConfiguration()
        {
            ToTable("Status");

            Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}
