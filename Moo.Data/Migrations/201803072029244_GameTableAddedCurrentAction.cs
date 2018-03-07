namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameTableAddedCurrentAction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "CurrentAction", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "CurrentAction");
        }
    }
}
