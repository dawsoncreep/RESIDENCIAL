namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class ExternalBinnacle_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExternalBinnaclePhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 200),
                        ExternalBinnacle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExternalBinnacles", t => t.ExternalBinnacle_Id)
                .Index(t => t.ExternalBinnacle_Id);
            
            AlterTableAnnotations(
                "dbo.ExternalBinnacles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        ExitDate = c.DateTime(nullable: false),
                        ExternalName = c.String(nullable: false, maxLength: 150),
                        ColonialName = c.String(nullable: false, maxLength: 150),
                        LicensePlateText = c.String(maxLength: 50),
                        LocationText = c.String(nullable: false, maxLength: 150),
                        ExternalTypeText = c.String(nullable: false, maxLength: 150),
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
                        "DynamicFilter_ExternalBinnacle_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AddColumn("dbo.ExternalBinnacles", "EntryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ExternalBinnacles", "ExitDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ExternalBinnacles", "ExternalName", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.ExternalBinnacles", "ColonialName", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.ExternalBinnacles", "LicensePlateText", c => c.String(maxLength: 50));
            AddColumn("dbo.ExternalBinnacles", "LocationText", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.ExternalBinnacles", "ExternalTypeText", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.ExternalBinnacles", "Deleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExternalBinnacles", "Deleted", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.ExternalBinnaclePhotoes", "ExternalBinnacle_Id", "dbo.ExternalBinnacles");
            DropIndex("dbo.ExternalBinnaclePhotoes", new[] { "ExternalBinnacle_Id" });
            DropColumn("dbo.ExternalBinnacles", "ExternalTypeText");
            DropColumn("dbo.ExternalBinnacles", "LocationText");
            DropColumn("dbo.ExternalBinnacles", "LicensePlateText");
            DropColumn("dbo.ExternalBinnacles", "ColonialName");
            DropColumn("dbo.ExternalBinnacles", "ExternalName");
            DropColumn("dbo.ExternalBinnacles", "ExitDate");
            DropColumn("dbo.ExternalBinnacles", "EntryDate");
            AlterTableAnnotations(
                "dbo.ExternalBinnacles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        ExitDate = c.DateTime(nullable: false),
                        ExternalName = c.String(nullable: false, maxLength: 150),
                        ColonialName = c.String(nullable: false, maxLength: 150),
                        LicensePlateText = c.String(maxLength: 50),
                        LocationText = c.String(nullable: false, maxLength: 150),
                        ExternalTypeText = c.String(nullable: false, maxLength: 150),
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
                        "DynamicFilter_ExternalBinnacle_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            DropTable("dbo.ExternalBinnaclePhotoes");
        }
    }
}
