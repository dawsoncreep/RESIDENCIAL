namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class externalUserproperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Externals", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Externals", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Externals", "UpdatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Externals", new[] { "CreatedBy" });
            DropIndex("dbo.Externals", new[] { "UpdatedBy" });
            DropIndex("dbo.Externals", new[] { "DeletedBy" });
            AlterTableAnnotations(
                "dbo.Externals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        FirtName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_External_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            DropForeignKey("dbo.Externals", "FK_dbo.Customers_dbo.AspNetUsers_CreatedBy");
            DropForeignKey("dbo.Externals", "FK_dbo.Customers_dbo.AspNetUsers_DeletedBy");
            DropForeignKey("dbo.Externals", "FK_dbo.Customers_dbo.AspNetUsers_UpdatedBy");
            AddColumn("dbo.Externals", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Externals", "FirtName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Externals", "LastName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Externals", "Deleted");
            DropColumn("dbo.Externals", "CreatedAt");
            DropColumn("dbo.Externals", "CreatedBy");
            DropColumn("dbo.Externals", "UpdatedAt");
            DropColumn("dbo.Externals", "UpdatedBy");
            DropColumn("dbo.Externals", "DeletedAt");
            DropColumn("dbo.Externals", "DeletedBy");

        }
        
        public override void Down()
        {
            AddColumn("dbo.Externals", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Externals", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Externals", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Externals", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Externals", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Externals", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Externals", "Deleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Externals", "LastName");
            DropColumn("dbo.Externals", "FirtName");
            DropColumn("dbo.Externals", "Name");
            AlterTableAnnotations(
                "dbo.Externals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        FirtName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_External_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            CreateIndex("dbo.Externals", "DeletedBy");
            CreateIndex("dbo.Externals", "UpdatedBy");
            CreateIndex("dbo.Externals", "CreatedBy");
            AddForeignKey("dbo.Externals", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Externals", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Externals", "CreatedBy", "dbo.AspNetUsers", "Id");

        }
    }
}
