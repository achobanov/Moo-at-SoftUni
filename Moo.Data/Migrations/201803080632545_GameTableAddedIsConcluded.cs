namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameTableAddedIsConcluded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "IsConcluded", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "IsConcluded");
        }
    }
}
