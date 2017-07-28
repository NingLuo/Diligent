using System.Data.Entity.ModelConfiguration;
using Diligent.BOL;

namespace Diligent.DAL.EntityCongfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("User");

            Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(254);

            Property(u => u.Password)
            .IsRequired();

            Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(30);
        }
    }
}
