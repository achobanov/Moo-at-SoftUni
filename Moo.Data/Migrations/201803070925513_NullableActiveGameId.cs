namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableActiveGameId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "ActiveGameID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "ActiveGameID", c => c.Int(nullable: false));
        }
    }
}
