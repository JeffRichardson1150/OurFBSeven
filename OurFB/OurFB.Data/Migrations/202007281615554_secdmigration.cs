namespace OurFB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secdmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Comment", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Post", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "UserId");
            DropColumn("dbo.Comment", "OwnerId");
            DropColumn("dbo.Comment", "Title");
        }
    }
}
