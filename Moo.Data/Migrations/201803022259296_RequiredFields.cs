namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Game", "User_ID", "dbo.User");
            DropIndex("dbo.Game", new[] { "User_ID" });
            AlterColumn("dbo.Game", "User_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
            CreateIndex("dbo.Game", "User_ID");
            AddForeignKey("dbo.Game", "User_ID", "dbo.User", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Game", "User_ID", "dbo.User");
            DropIndex("dbo.Game", new[] { "User_ID" });
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "Username", c => c.String());
            AlterColumn("dbo.Game", "User_ID", c => c.Int());
            CreateIndex("dbo.Game", "User_ID");
            AddForeignKey("dbo.Game", "User_ID", "dbo.User", "ID");
        }
    }
}
