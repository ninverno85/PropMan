namespace Co11PropProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itsFriday : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Properties", "UserId");
            AddForeignKey("dbo.Properties", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Properties", "UserId", "dbo.Users");
            DropIndex("dbo.Properties", new[] { "UserId" });
        }
    }
}
