namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201909032211345_AddingExternalTypeAndExternalProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Externals", "Image", c => c.String(maxLength: 200));
            DropColumn("dbo.Externals", "UrlImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Externals", "UrlImage", c => c.String(maxLength: 200));
            DropColumn("dbo.Externals", "Image");
        }
    }
}
