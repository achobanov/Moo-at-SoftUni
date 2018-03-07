namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetGameTurnsInSingleCollection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Turn", "Game_ID", "dbo.Game");
            DropIndex("dbo.Turn", new[] { "Game_ID" });
            DropColumn("dbo.Turn", "Game_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Turn", "Game_ID", c => c.Int());
            CreateIndex("dbo.Turn", "Game_ID");
            AddForeignKey("dbo.Turn", "Game_ID", "dbo.Game", "ID");
        }
    }
}
