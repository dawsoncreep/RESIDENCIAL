namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CatalogosType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BinnacleTypes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BinnacleTypes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BinnacleTypes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventTypes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventTypes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventTypes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BinnaclePhotoTypes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BinnaclePhotoTypes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BinnaclePhotoTypes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationTypes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationTypes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationTypes", "UpdatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.BinnacleTypes", new[] { "CreatedBy" });
            DropIndex("dbo.BinnacleTypes", new[] { "UpdatedBy" });
            DropIndex("dbo.BinnacleTypes", new[] { "DeletedBy" });
            DropIndex("dbo.EventTypes", new[] { "CreatedBy" });
            DropIndex("dbo.EventTypes", new[] { "UpdatedBy" });
            DropIndex("dbo.EventTypes", new[] { "DeletedBy" });
            DropIndex("dbo.BinnaclePhotoTypes", new[] { "CreatedBy" });
            DropIndex("dbo.BinnaclePhotoTypes", new[] { "UpdatedBy" });
            DropIndex("dbo.BinnaclePhotoTypes", new[] { "DeletedBy" });
            DropIndex("dbo.LocationTypes", new[] { "CreatedBy" });
            DropIndex("dbo.LocationTypes", new[] { "UpdatedBy" });
            DropIndex("dbo.LocationTypes", new[] { "DeletedBy" });
            AddColumn("dbo.BinnacleTypes", "Description", c => c.String());
            AddColumn("dbo.BinnaclePhotoTypes", "Description", c => c.String());
            AddColumn("dbo.LocationTypes", "Description", c => c.String());
            AlterColumn("dbo.Binnacles", "Name", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.BinnacleTypes", "CreatedAt");
            DropColumn("dbo.BinnacleTypes", "CreatedBy");
            DropColumn("dbo.BinnacleTypes", "UpdatedAt");
            DropColumn("dbo.BinnacleTypes", "UpdatedBy");
            DropColumn("dbo.BinnacleTypes", "DeletedAt");
            DropColumn("dbo.BinnacleTypes", "DeletedBy");
            DropColumn("dbo.EventTypes", "CreatedAt");
            DropColumn("dbo.EventTypes", "CreatedBy");
            DropColumn("dbo.EventTypes", "UpdatedAt");
            DropColumn("dbo.EventTypes", "UpdatedBy");
            DropColumn("dbo.EventTypes", "DeletedAt");
            DropColumn("dbo.EventTypes", "DeletedBy");
            DropColumn("dbo.BinnaclePhotoTypes", "CreatedAt");
            DropColumn("dbo.BinnaclePhotoTypes", "CreatedBy");
            DropColumn("dbo.BinnaclePhotoTypes", "UpdatedAt");
            DropColumn("dbo.BinnaclePhotoTypes", "UpdatedBy");
            DropColumn("dbo.BinnaclePhotoTypes", "DeletedAt");
            DropColumn("dbo.BinnaclePhotoTypes", "DeletedBy");
            DropColumn("dbo.LocationTypes", "CreatedAt");
            DropColumn("dbo.LocationTypes", "CreatedBy");
            DropColumn("dbo.LocationTypes", "UpdatedAt");
            DropColumn("dbo.LocationTypes", "UpdatedBy");
            DropColumn("dbo.LocationTypes", "DeletedAt");
            DropColumn("dbo.LocationTypes", "DeletedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LocationTypes", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.LocationTypes", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.LocationTypes", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.LocationTypes", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.LocationTypes", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.LocationTypes", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.BinnaclePhotoTypes", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.BinnaclePhotoTypes", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.BinnaclePhotoTypes", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.BinnaclePhotoTypes", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.BinnaclePhotoTypes", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.BinnaclePhotoTypes", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.EventTypes", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.EventTypes", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.EventTypes", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.EventTypes", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.EventTypes", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.EventTypes", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.BinnacleTypes", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.BinnacleTypes", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.BinnacleTypes", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.BinnacleTypes", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.BinnacleTypes", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.BinnacleTypes", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Binnacles", "Name", c => c.String(maxLength: 100));
            DropColumn("dbo.LocationTypes", "Description");
            DropColumn("dbo.BinnaclePhotoTypes", "Description");
            DropColumn("dbo.BinnacleTypes", "Description");
            CreateIndex("dbo.LocationTypes", "DeletedBy");
            CreateIndex("dbo.LocationTypes", "UpdatedBy");
            CreateIndex("dbo.LocationTypes", "CreatedBy");
            CreateIndex("dbo.BinnaclePhotoTypes", "DeletedBy");
            CreateIndex("dbo.BinnaclePhotoTypes", "UpdatedBy");
            CreateIndex("dbo.BinnaclePhotoTypes", "CreatedBy");
            CreateIndex("dbo.EventTypes", "DeletedBy");
            CreateIndex("dbo.EventTypes", "UpdatedBy");
            CreateIndex("dbo.EventTypes", "CreatedBy");
            CreateIndex("dbo.BinnacleTypes", "DeletedBy");
            CreateIndex("dbo.BinnacleTypes", "UpdatedBy");
            CreateIndex("dbo.BinnacleTypes", "CreatedBy");
            AddForeignKey("dbo.LocationTypes", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.LocationTypes", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.LocationTypes", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.BinnaclePhotoTypes", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.BinnaclePhotoTypes", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.BinnaclePhotoTypes", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.EventTypes", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.EventTypes", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.EventTypes", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.BinnacleTypes", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.BinnacleTypes", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.BinnacleTypes", "CreatedBy", "dbo.AspNetUsers", "Id");
        }
    }
}
