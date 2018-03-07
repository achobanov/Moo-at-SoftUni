namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoIdea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Turn", "Cows", c => c.Int());
            AddColumn("dbo.Turn", "Bulls", c => c.Int());
            DropColumn("dbo.Turn", "ResponseCows");
            DropColumn("dbo.Turn", "ResponseBulls");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Turn", "ResponseBulls", c => c.Int());
            AddColumn("dbo.Turn", "ResponseCows", c => c.Int());
            DropColumn("dbo.Turn", "Bulls");
            DropColumn("dbo.Turn", "Cows");
        }
    }
}
