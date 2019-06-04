namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFieldsToEvent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventTypes", "Event_Id", "dbo.Events");
            DropIndex("dbo.EventTypes", new[] { "Event_Id" });
            AlterTableAnnotations(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 100),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        EventType_Id = c.Int(),
                        External_Id = c.Int(),
                        Location_Id = c.Int(),
                        Binnacle_Id = c.Int(),
                        EventLocation_Id = c.Int(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Event_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AddColumn("dbo.Events", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Events", "Description", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Events", "DateStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "DateEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "EventType_Id", c => c.Int());
            AddColumn("dbo.Events", "External_Id", c => c.Int());
            AddColumn("dbo.Events", "Location_Id", c => c.Int());
            CreateIndex("dbo.Events", "EventType_Id");
            CreateIndex("dbo.Events", "External_Id");
            CreateIndex("dbo.Events", "Location_Id");
            AddForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes", "Id");
            AddForeignKey("dbo.Events", "External_Id", "dbo.Externals", "Id");
            AddForeignKey("dbo.Events", "Location_Id", "dbo.Locations", "Id");
            DropColumn("dbo.Events", "Deleted");
            DropColumn("dbo.EventTypes", "Event_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventTypes", "Event_Id", c => c.Int());
            AddColumn("dbo.Events", "Deleted", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Events", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Events", "External_Id", "dbo.Externals");
            DropForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "Location_Id" });
            DropIndex("dbo.Events", new[] { "External_Id" });
            DropIndex("dbo.Events", new[] { "EventType_Id" });
            DropColumn("dbo.Events", "Location_Id");
            DropColumn("dbo.Events", "External_Id");
            DropColumn("dbo.Events", "EventType_Id");
            DropColumn("dbo.Events", "DateEnd");
            DropColumn("dbo.Events", "DateStart");
            DropColumn("dbo.Events", "Description");
            DropColumn("dbo.Events", "Name");
            AlterTableAnnotations(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 100),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        EventType_Id = c.Int(),
                        External_Id = c.Int(),
                        Location_Id = c.Int(),
                        Binnacle_Id = c.Int(),
                        EventLocation_Id = c.Int(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Event_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            CreateIndex("dbo.EventTypes", "Event_Id");
            AddForeignKey("dbo.EventTypes", "Event_Id", "dbo.Events", "Id");
        }
    }
}
