namespace Diligent.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 2000),
                        StartDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        StatusId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.ReviewMission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewDate = c.DateTime(nullable: false),
                        TaskId = c.Int(nullable: false),
                        StatusId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.Task", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 254),
                        Password = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "UserId", "dbo.User");
            DropForeignKey("dbo.Task", "StatusId", "dbo.Status");
            DropForeignKey("dbo.ReviewMission", "TaskId", "dbo.Task");
            DropForeignKey("dbo.ReviewMission", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Task", "CategoryId", "dbo.Category");
            DropIndex("dbo.ReviewMission", new[] { "StatusId" });
            DropIndex("dbo.ReviewMission", new[] { "TaskId" });
            DropIndex("dbo.Task", new[] { "StatusId" });
            DropIndex("dbo.Task", new[] { "CategoryId" });
            DropIndex("dbo.Task", new[] { "UserId" });
            DropTable("dbo.User");
            DropTable("dbo.Status");
            DropTable("dbo.ReviewMission");
            DropTable("dbo.Task");
            DropTable("dbo.Category");
        }
    }
}
