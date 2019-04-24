namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class permissionAddRouingProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Permissions", "Action", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Permissions", "Controller", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Permissions", "Area", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Permissions", "Area");
            DropColumn("dbo.Permissions", "Controller");
            DropColumn("dbo.Permissions", "Action");
        }
    }
}
