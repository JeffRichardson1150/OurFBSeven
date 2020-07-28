namespace OurFB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Post", "UserId");
            AddForeignKey("dbo.Post", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "UserId", "dbo.User");
            DropIndex("dbo.Post", new[] { "UserId" });
            DropColumn("dbo.Post", "UserId");
        }
    }
}
