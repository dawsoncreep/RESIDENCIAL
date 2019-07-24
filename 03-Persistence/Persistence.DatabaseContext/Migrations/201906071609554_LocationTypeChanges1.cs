namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationTypeChanges1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocationTypes", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LocationTypes", "Name");
        }
    }
}
