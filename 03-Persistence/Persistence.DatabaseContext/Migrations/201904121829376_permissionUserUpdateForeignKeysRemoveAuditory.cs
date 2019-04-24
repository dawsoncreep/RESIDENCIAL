namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class permissionUserUpdateForeignKeysRemoveAuditory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PermissionUsers", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.PermissionUsers", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.PermissionUsers", "UpdatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.PermissionUsers", new[] { "CreatedBy" });
            DropIndex("dbo.PermissionUsers", new[] { "UpdatedBy" });
            DropIndex("dbo.PermissionUsers", new[] { "DeletedBy" });
            DropColumn("dbo.PermissionUsers", "CreatedAt");
            DropColumn("dbo.PermissionUsers", "CreatedBy");
            DropColumn("dbo.PermissionUsers", "UpdatedAt");
            DropColumn("dbo.PermissionUsers", "UpdatedBy");
            DropColumn("dbo.PermissionUsers", "DeletedAt");
            DropColumn("dbo.PermissionUsers", "DeletedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PermissionUsers", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.PermissionUsers", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.PermissionUsers", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.PermissionUsers", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.PermissionUsers", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.PermissionUsers", "CreatedAt", c => c.DateTime());
            CreateIndex("dbo.PermissionUsers", "DeletedBy");
            CreateIndex("dbo.PermissionUsers", "UpdatedBy");
            CreateIndex("dbo.PermissionUsers", "CreatedBy");
            AddForeignKey("dbo.PermissionUsers", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PermissionUsers", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PermissionUsers", "CreatedBy", "dbo.AspNetUsers", "Id");
        }
    }
}
