namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class addTablesParameterBulletin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationParameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
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
                    { "DynamicFilter_ApplicationParameters_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Bulletins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                    { "DynamicFilter_Bulletin_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bulletins", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bulletins", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bulletins", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationParameters", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationParameters", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationParameters", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Bulletins", new[] { "DeletedBy" });
            DropIndex("dbo.Bulletins", new[] { "UpdatedBy" });
            DropIndex("dbo.Bulletins", new[] { "CreatedBy" });
            DropIndex("dbo.ApplicationParameters", new[] { "DeletedBy" });
            DropIndex("dbo.ApplicationParameters", new[] { "UpdatedBy" });
            DropIndex("dbo.ApplicationParameters", new[] { "CreatedBy" });
            DropTable("dbo.Bulletins",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Bulletin_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ApplicationParameters",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ApplicationParameters_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
