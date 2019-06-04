namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingLocationValidations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locations", "LocationType_Id", "dbo.LocationTypes");
            DropIndex("dbo.Locations", new[] { "LocationType_Id" });
            AlterColumn("dbo.Locations", "LocationType_Id", c => c.Int());
            CreateIndex("dbo.Locations", "LocationType_Id");
            AddForeignKey("dbo.Locations", "LocationType_Id", "dbo.LocationTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "LocationType_Id", "dbo.LocationTypes");
            DropIndex("dbo.Locations", new[] { "LocationType_Id" });
            AlterColumn("dbo.Locations", "LocationType_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "LocationType_Id");
            AddForeignKey("dbo.Locations", "LocationType_Id", "dbo.LocationTypes", "Id", cascadeDelete: true);
        }
    }
}
