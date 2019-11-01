namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class BinnaclePhotoType : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.BinnaclePhotoTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BinnaclePhotoType_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterColumn("dbo.BinnaclePhotoTypes", "Description", c => c.String(maxLength: 100));
            DropColumn("dbo.BinnaclePhotoTypes", "Deleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BinnaclePhotoTypes", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.BinnaclePhotoTypes", "Description", c => c.String());
            AlterTableAnnotations(
                "dbo.BinnaclePhotoTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BinnaclePhotoType_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
        }
    }
}
