namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class externalFirstName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Externals", "FirstName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Externals", "FirtName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Externals", "FirtName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Externals", "FirstName");
        }
    }
}
