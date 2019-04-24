namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Permission_PermissionUserphysicalDelete : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResourceCode = c.String(maxLength: 30),
                        Name = c.String(maxLength: 30),
                        Description = c.String(maxLength: 200),
                        Action = c.String(nullable: false, maxLength: 100),
                        Controller = c.String(nullable: false, maxLength: 100),
                        Area = c.String(nullable: false, maxLength: 100),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Permission_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.PermissionUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Permission_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_PermissionUser_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            DropColumn("dbo.Permissions", "Deleted");
            DropColumn("dbo.PermissionUsers", "Deleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PermissionUsers", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Permissions", "Deleted", c => c.Boolean(nullable: false));
            AlterTableAnnotations(
                "dbo.PermissionUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Permission_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_PermissionUser_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResourceCode = c.String(maxLength: 30),
                        Name = c.String(maxLength: 30),
                        Description = c.String(maxLength: 200),
                        Action = c.String(nullable: false, maxLength: 100),
                        Controller = c.String(nullable: false, maxLength: 100),
                        Area = c.String(nullable: false, maxLength: 100),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Permission_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
        }
    }
}
