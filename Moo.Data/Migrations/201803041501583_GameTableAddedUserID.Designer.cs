// <auto-generated />
namespace Moo.Data.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class GameTableAddedUserID : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(GameTableAddedUserID));
        
        string IMigrationMetadata.Id
        {
            get { return "201803041501583_GameTableAddedUserID"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
