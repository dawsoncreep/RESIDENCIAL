namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationParameterAddingDescripcionAttributesAndAnnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationParameters", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationParameters", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationParameters", "UpdatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationParameters", new[] { "CreatedBy" });
            DropIndex("dbo.ApplicationParameters", new[] { "UpdatedBy" });
            DropIndex("dbo.ApplicationParameters", new[] { "DeletedBy" });
            AlterTableAnnotations(
                "dbo.ApplicationParameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 50),
                        Value = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 100),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ApplicationParameters_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AddColumn("dbo.ApplicationParameters", "Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.ApplicationParameters", "Key", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ApplicationParameters", "Value", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.ApplicationParameters", "Deleted");
            DropColumn("dbo.ApplicationParameters", "CreatedAt");
            DropColumn("dbo.ApplicationParameters", "CreatedBy");
            DropColumn("dbo.ApplicationParameters", "UpdatedAt");
            DropColumn("dbo.ApplicationParameters", "UpdatedBy");
            DropColumn("dbo.ApplicationParameters", "DeletedAt");
            DropColumn("dbo.ApplicationParameters", "DeletedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationParameters", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.ApplicationParameters", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.ApplicationParameters", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.ApplicationParameters", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.ApplicationParameters", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.ApplicationParameters", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.ApplicationParameters", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ApplicationParameters", "Value", c => c.String());
            AlterColumn("dbo.ApplicationParameters", "Key", c => c.String());
            DropColumn("dbo.ApplicationParameters", "Description");
            AlterTableAnnotations(
                "dbo.ApplicationParameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 50),
                        Value = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 100),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ApplicationParameters_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            CreateIndex("dbo.ApplicationParameters", "DeletedBy");
            CreateIndex("dbo.ApplicationParameters", "UpdatedBy");
            CreateIndex("dbo.ApplicationParameters", "CreatedBy");
            AddForeignKey("dbo.ApplicationParameters", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ApplicationParameters", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ApplicationParameters", "CreatedBy", "dbo.AspNetUsers", "Id");
        }
    }
}
