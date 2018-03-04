namespace Moo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameTableAddedUserID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Game", name: "User_ID", newName: "UserID");
            RenameIndex(table: "dbo.Game", name: "IX_User_ID", newName: "IX_UserID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Game", name: "IX_UserID", newName: "IX_User_ID");
            RenameColumn(table: "dbo.Game", name: "UserID", newName: "User_ID");
        }
    }
}
