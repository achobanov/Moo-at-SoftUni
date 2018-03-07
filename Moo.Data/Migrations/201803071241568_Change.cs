namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Turn", "Game_ID", c => c.Int());
            CreateIndex("dbo.Turn", "GameID");
            CreateIndex("dbo.Turn", "Game_ID");
            AddForeignKey("dbo.Turn", "Game_ID", "dbo.Game", "ID");
            AddForeignKey("dbo.Turn", "GameID", "dbo.Game", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Turn", "GameID", "dbo.Game");
            DropForeignKey("dbo.Turn", "Game_ID", "dbo.Game");
            DropIndex("dbo.Turn", new[] { "Game_ID" });
            DropIndex("dbo.Turn", new[] { "GameID" });
            DropColumn("dbo.Turn", "Game_ID");
        }
    }
}
