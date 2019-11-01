namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class BinnaclePhoto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BinnacleTypes", "BinnaclePhoto_Id", "dbo.BinnaclePhotoes");
            DropIndex("dbo.BinnacleTypes", new[] { "BinnaclePhoto_Id" });
            AlterTableAnnotations(
                "dbo.BinnaclePhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BinnaclePhoto_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            DropColumn("dbo.BinnacleTypes", "BinnaclePhoto_Id");
            DropColumn("dbo.BinnaclePhotoes", "Deleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BinnaclePhotoes", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.BinnacleTypes", "BinnaclePhoto_Id", c => c.Int());
            AlterTableAnnotations(
                "dbo.BinnaclePhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BinnaclePhoto_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            CreateIndex("dbo.BinnacleTypes", "BinnaclePhoto_Id");
            AddForeignKey("dbo.BinnacleTypes", "BinnaclePhoto_Id", "dbo.BinnaclePhotoes", "Id");
        }
    }
}
