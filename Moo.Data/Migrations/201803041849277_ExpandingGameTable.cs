namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpandingGameTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "UserWon", c => c.Boolean(nullable: false));
            AddColumn("dbo.Game", "Draw", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "ActiveGameID", c => c.Int(nullable: false));
            DropColumn("dbo.Game", "HasUserWon");
            DropColumn("dbo.User", "FirstName");
            DropColumn("dbo.User", "LastName");
            DropColumn("dbo.User", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Email", c => c.String());
            AddColumn("dbo.User", "LastName", c => c.String());
            AddColumn("dbo.User", "FirstName", c => c.String());
            AddColumn("dbo.Game", "HasUserWon", c => c.Boolean(nullable: false));
            DropColumn("dbo.User", "ActiveGameID");
            DropColumn("dbo.Game", "Draw");
            DropColumn("dbo.Game", "UserWon");
        }
    }
}
