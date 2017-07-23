using System.Data.Entity.ModelConfiguration;
using Diligent.BOL;

namespace Diligent.DAL.EntityCongfigurations
{
    public class ReviewMissionConfiguration : EntityTypeConfiguration<ReviewMission>
    {
        public ReviewMissionConfiguration()
        {
            ToTable("ReviewMission");

            HasRequired(rm => rm.Status)
            .WithMany()
            .HasForeignKey(rm => rm.StatusId)
            .WillCascadeOnDelete(false);
        }
    }
}
