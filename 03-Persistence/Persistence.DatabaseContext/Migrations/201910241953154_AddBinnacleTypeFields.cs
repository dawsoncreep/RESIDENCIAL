namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddBinnacleTypeFields : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.BinnacleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100),
                        Binnacle_Id = c.Int(),
                        BinnaclePhoto_Id = c.Int(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BinnacleType_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterColumn("dbo.BinnacleTypes", "Description", c => c.String(maxLength: 100));
            DropColumn("dbo.BinnacleTypes", "Deleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BinnacleTypes", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.BinnacleTypes", "Description", c => c.String());
            AlterTableAnnotations(
                "dbo.BinnacleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100),
                        Binnacle_Id = c.Int(),
                        BinnaclePhoto_Id = c.Int(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_BinnacleType_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
        }
    }
}
