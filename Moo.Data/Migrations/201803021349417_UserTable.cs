namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Game", "User_ID", c => c.Int());
            CreateIndex("dbo.Game", "User_ID");
            AddForeignKey("dbo.Game", "User_ID", "dbo.User", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Game", "User_ID", "dbo.User");
            DropIndex("dbo.Game", new[] { "User_ID" });
            DropColumn("dbo.Game", "User_ID");
            DropTable("dbo.User");
        }
    }
}
