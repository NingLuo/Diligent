namespace Diligent.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCategorytoProjectuseprojectasconnectionbetweenuserandtask : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Task", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Task", "UserId", "dbo.User");
            DropIndex("dbo.Task", new[] { "UserId" });
            DropIndex("dbo.Task", new[] { "CategoryId" });
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Task", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Task", "ProjectId");
            AddForeignKey("dbo.Task", "ProjectId", "dbo.Project", "Id", cascadeDelete: true);
            DropColumn("dbo.Task", "UserId");
            DropColumn("dbo.Task", "CategoryId");
            DropTable("dbo.Category");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Task", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Task", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Project", "UserId", "dbo.User");
            DropForeignKey("dbo.Task", "ProjectId", "dbo.Project");
            DropIndex("dbo.Task", new[] { "ProjectId" });
            DropIndex("dbo.Project", new[] { "UserId" });
            DropColumn("dbo.Task", "ProjectId");
            DropTable("dbo.Project");
            CreateIndex("dbo.Task", "CategoryId");
            CreateIndex("dbo.Task", "UserId");
            AddForeignKey("dbo.Task", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Task", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
        }
    }
}
