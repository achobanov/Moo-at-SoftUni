namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Turn",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GameID = c.Int(nullable: false),
                        Index = c.Int(nullable: false),
                        Action = c.String(),
                        Guess = c.String(),
                        ResponseCows = c.Int(),
                        ResponseBulls = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Game", "UserNumber", c => c.String(nullable: false));
            AddColumn("dbo.Game", "OpponentNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "OpponentNumber");
            DropColumn("dbo.Game", "UserNumber");
            DropTable("dbo.Turn");
        }
    }
}
