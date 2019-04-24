namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setDefaultToPermissions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Permissions", "ResourceCode", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Permissions", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Permissions", "Description", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Permissions", "Action", c => c.String(maxLength: 100));
            AlterColumn("dbo.Permissions", "Controller", c => c.String(maxLength: 100));
            AlterColumn("dbo.Permissions", "Area", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Permissions", "Area", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Permissions", "Controller", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Permissions", "Action", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Permissions", "Description", c => c.String(maxLength: 200));
            AlterColumn("dbo.Permissions", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Permissions", "ResourceCode", c => c.String(maxLength: 30));
        }
    }
}
