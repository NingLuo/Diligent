using System.Data.Entity;
using Diligent.BOL;
using Diligent.DAL.EntityCongfigurations;

namespace Diligent.DAL
{
    public class DiligentContext : DbContext
    {
        private const string DevConnection = "DiligentDev";
        public DiligentContext():base(DevConnection)
        {
            
        }

        public DbSet<Project> Projects { get; set; }              
        public DbSet<ReviewMission> ReviewMissions { get; set; }        
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProjectConfiguration());
            modelBuilder.Configurations.Add(new ReviewMissionConfiguration());
            modelBuilder.Configurations.Add(new StatusConfiguration());
            modelBuilder.Configurations.Add(new TaskConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());                                 
        }
    }
}
