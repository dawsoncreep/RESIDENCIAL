namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingAuditIsoftLocationUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LocationUsers", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationUsers", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationUsers", "UpdatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.LocationUsers", new[] { "CreatedBy" });
            DropIndex("dbo.LocationUsers", new[] { "UpdatedBy" });
            DropIndex("dbo.LocationUsers", new[] { "DeletedBy" });
            AlterTableAnnotations(
                "dbo.LocationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationUserNotification_Id = c.Int(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_LocationUser_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            DropColumn("dbo.LocationUsers", "Deleted");
            DropColumn("dbo.LocationUsers", "CreatedAt");
            DropColumn("dbo.LocationUsers", "CreatedBy");
            DropColumn("dbo.LocationUsers", "UpdatedAt");
            DropColumn("dbo.LocationUsers", "UpdatedBy");
            DropColumn("dbo.LocationUsers", "DeletedAt");
            DropColumn("dbo.LocationUsers", "DeletedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LocationUsers", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.LocationUsers", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.LocationUsers", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.LocationUsers", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.LocationUsers", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.LocationUsers", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.LocationUsers", "Deleted", c => c.Boolean(nullable: false));
            AlterTableAnnotations(
                "dbo.LocationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationUserNotification_Id = c.Int(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_LocationUser_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            CreateIndex("dbo.LocationUsers", "DeletedBy");
            CreateIndex("dbo.LocationUsers", "UpdatedBy");
            CreateIndex("dbo.LocationUsers", "CreatedBy");
            AddForeignKey("dbo.LocationUsers", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.LocationUsers", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.LocationUsers", "CreatedBy", "dbo.AspNetUsers", "Id");
        }
    }
}
