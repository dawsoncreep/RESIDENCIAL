namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddingLocationProperties : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        EventLocation_Id = c.Int(),
                        LocationTelephone_Id = c.Int(),
                        LocationUser_Id = c.Int(),
                        LocationVehicle_Id = c.Int(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Location_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AddColumn("dbo.EventTypes", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.EventTypes", "OutNumber", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.EventTypes", "InNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Locations", "Name", c => c.String());
            AddColumn("dbo.Locations", "Description", c => c.String());
            AlterColumn("dbo.EventTypes", "Description", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Locations", "Deleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.EventTypes", "Description", c => c.String());
            DropColumn("dbo.Locations", "Description");
            DropColumn("dbo.Locations", "Name");
            DropColumn("dbo.EventTypes", "InNumber");
            DropColumn("dbo.EventTypes", "OutNumber");
            DropColumn("dbo.EventTypes", "Name");
            AlterTableAnnotations(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        EventLocation_Id = c.Int(),
                        LocationTelephone_Id = c.Int(),
                        LocationUser_Id = c.Int(),
                        LocationVehicle_Id = c.Int(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Location_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
        }
    }
}
