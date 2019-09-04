namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingExternalTypeAndExternalProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExternalTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Externals", "LicensePlate", c => c.String(maxLength: 50));
            AddColumn("dbo.Externals", "UrlImage", c => c.String(maxLength: 200));
            AddColumn("dbo.Externals", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Externals", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Externals", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Externals", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Externals", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Externals", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Externals", "ExternalType_Id", c => c.Int());
            CreateIndex("dbo.Externals", "CreatedBy");
            CreateIndex("dbo.Externals", "UpdatedBy");
            CreateIndex("dbo.Externals", "DeletedBy");
            CreateIndex("dbo.Externals", "ExternalType_Id");
            AddForeignKey("dbo.Externals", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Externals", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Externals", "ExternalType_Id", "dbo.ExternalTypes", "Id");
            AddForeignKey("dbo.Externals", "UpdatedBy", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Externals", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Externals", "ExternalType_Id", "dbo.ExternalTypes");
            DropForeignKey("dbo.Externals", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Externals", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Externals", new[] { "ExternalType_Id" });
            DropIndex("dbo.Externals", new[] { "DeletedBy" });
            DropIndex("dbo.Externals", new[] { "UpdatedBy" });
            DropIndex("dbo.Externals", new[] { "CreatedBy" });
            DropColumn("dbo.Externals", "ExternalType_Id");
            DropColumn("dbo.Externals", "DeletedBy");
            DropColumn("dbo.Externals", "DeletedAt");
            DropColumn("dbo.Externals", "UpdatedBy");
            DropColumn("dbo.Externals", "UpdatedAt");
            DropColumn("dbo.Externals", "CreatedBy");
            DropColumn("dbo.Externals", "CreatedAt");
            DropColumn("dbo.Externals", "UrlImage");
            DropColumn("dbo.Externals", "LicensePlate");
            DropTable("dbo.ExternalTypes");
        }
    }
}
