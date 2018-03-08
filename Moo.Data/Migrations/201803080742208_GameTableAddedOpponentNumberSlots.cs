namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameTableAddedOpponentNumberSlots : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "OpponentNumberSlots", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "OpponentNumberSlots");
        }
    }
}
