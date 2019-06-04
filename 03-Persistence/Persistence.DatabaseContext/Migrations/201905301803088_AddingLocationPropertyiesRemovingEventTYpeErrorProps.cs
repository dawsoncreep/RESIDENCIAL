namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingLocationPropertyiesRemovingEventTYpeErrorProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "OutNumber", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Locations", "InNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Locations", "LocationType_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Locations", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Locations", "Description", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.LocationTypes", "Description", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Locations", "LocationType_Id");
            AddForeignKey("dbo.Locations", "LocationType_Id", "dbo.LocationTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.EventTypes", "Name");
            DropColumn("dbo.EventTypes", "OutNumber");
            DropColumn("dbo.EventTypes", "InNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventTypes", "InNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.EventTypes", "OutNumber", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.EventTypes", "Name", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Locations", "LocationType_Id", "dbo.LocationTypes");
            DropIndex("dbo.Locations", new[] { "LocationType_Id" });
            AlterColumn("dbo.LocationTypes", "Description", c => c.String());
            AlterColumn("dbo.Locations", "Description", c => c.String());
            AlterColumn("dbo.Locations", "Name", c => c.String());
            DropColumn("dbo.Locations", "LocationType_Id");
            DropColumn("dbo.Locations", "InNumber");
            DropColumn("dbo.Locations", "OutNumber");
        }
    }
}
