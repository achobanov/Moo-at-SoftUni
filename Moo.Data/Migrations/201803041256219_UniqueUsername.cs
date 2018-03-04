namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueUsername : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.User", "Username", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "Username" });
        }
    }
}
