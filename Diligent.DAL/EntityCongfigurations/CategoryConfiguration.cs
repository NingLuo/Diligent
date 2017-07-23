using System.Data.Entity.ModelConfiguration;
using Diligent.BOL;

namespace Diligent.DAL.EntityCongfigurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Category");

            Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}
