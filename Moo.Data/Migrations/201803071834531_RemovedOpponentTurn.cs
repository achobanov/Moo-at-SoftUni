namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedOpponentTurn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Turn", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Turn", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
