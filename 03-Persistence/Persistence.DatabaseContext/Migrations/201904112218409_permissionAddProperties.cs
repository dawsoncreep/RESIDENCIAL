namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class permissionAddProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Permissions", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Permissions", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Permissions", "UpdatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Permissions", new[] { "CreatedBy" });
            DropIndex("dbo.Permissions", new[] { "UpdatedBy" });
            DropIndex("dbo.Permissions", new[] { "DeletedBy" });
            AddColumn("dbo.Permissions", "ResourceCode", c => c.String(maxLength: 30));
            AddColumn("dbo.Permissions", "Name", c => c.String(maxLength: 30));
            AddColumn("dbo.Permissions", "Description", c => c.String(maxLength: 200));
            AddColumn("dbo.Permissions", "PermissionMasterId_Id", c => c.Int());
            CreateIndex("dbo.Permissions", "PermissionMasterId_Id");
            AddForeignKey("dbo.Permissions", "PermissionMasterId_Id", "dbo.Permissions", "Id");
            DropColumn("dbo.Permissions", "CreatedAt");
            DropColumn("dbo.Permissions", "CreatedBy");
            DropColumn("dbo.Permissions", "UpdatedAt");
            DropColumn("dbo.Permissions", "UpdatedBy");
            DropColumn("dbo.Permissions", "DeletedAt");
            DropColumn("dbo.Permissions", "DeletedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Permissions", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Permissions", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Permissions", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Permissions", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Permissions", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Permissions", "CreatedAt", c => c.DateTime());
            DropForeignKey("dbo.Permissions", "PermissionMasterId_Id", "dbo.Permissions");
            DropIndex("dbo.Permissions", new[] { "PermissionMasterId_Id" });
            DropColumn("dbo.Permissions", "PermissionMasterId_Id");
            DropColumn("dbo.Permissions", "Description");
            DropColumn("dbo.Permissions", "Name");
            DropColumn("dbo.Permissions", "ResourceCode");
            CreateIndex("dbo.Permissions", "DeletedBy");
            CreateIndex("dbo.Permissions", "UpdatedBy");
            CreateIndex("dbo.Permissions", "CreatedBy");
            AddForeignKey("dbo.Permissions", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Permissions", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Permissions", "CreatedBy", "dbo.AspNetUsers", "Id");
        }
    }
}
