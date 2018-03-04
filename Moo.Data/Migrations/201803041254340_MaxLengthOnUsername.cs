namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthOnUsername : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Username", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Username", c => c.String(nullable: false));
        }
    }
}
