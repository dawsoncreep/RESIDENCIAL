namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAudiences : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audiences",
                c => new
                    {
                        ClientId = c.String(nullable: false, maxLength: 128),
                        Base64Secret = c.String(),
                        Name = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Audience_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Audiences", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Audiences", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Audiences", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Audiences", new[] { "DeletedBy" });
            DropIndex("dbo.Audiences", new[] { "UpdatedBy" });
            DropIndex("dbo.Audiences", new[] { "CreatedBy" });
            DropTable("dbo.Audiences",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Audience_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
