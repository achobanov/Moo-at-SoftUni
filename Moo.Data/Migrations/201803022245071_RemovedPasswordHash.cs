namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedPasswordHash : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "IsActive");
            DropColumn("dbo.User", "ActivationCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "ActivationCode", c => c.Guid(nullable: false));
            AddColumn("dbo.User", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}
