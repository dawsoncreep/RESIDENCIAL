namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class permissionUserUpdateForeignKeys : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.AspNetUsers", "PermissionUser_Id", "dbo.PermissionUsers");
            //DropForeignKey("dbo.Permissions", "PermissionUser_Id", "dbo.PermissionUsers");
            //DropIndex("dbo.AspNetUsers", new[] { "PermissionUser_Id" });
            //DropIndex("dbo.Permissions", new[] { "PermissionUser_Id" });
            AddColumn("dbo.PermissionUsers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.PermissionUsers", "Permission_Id", c => c.Int());
            CreateIndex("dbo.PermissionUsers", "ApplicationUser_Id");
            CreateIndex("dbo.PermissionUsers", "Permission_Id");
            AddForeignKey("dbo.PermissionUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PermissionUsers", "Permission_Id", "dbo.Permissions", "Id");
            //DropColumn("dbo.AspNetUsers", "PermissionUser_Id");
            //DropColumn("dbo.Permissions", "PermissionUser_Id");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Permissions", "PermissionUser_Id", c => c.Int());
            //AddColumn("dbo.AspNetUsers", "PermissionUser_Id", c => c.Int());
            DropForeignKey("dbo.PermissionUsers", "Permission_Id", "dbo.Permissions");
            DropForeignKey("dbo.PermissionUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PermissionUsers", new[] { "Permission_Id" });
            DropIndex("dbo.PermissionUsers", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.PermissionUsers", "Permission_Id");
            DropColumn("dbo.PermissionUsers", "ApplicationUser_Id");
            //CreateIndex("dbo.Permissions", "PermissionUser_Id");
            //CreateIndex("dbo.AspNetUsers", "PermissionUser_Id");
            //AddForeignKey("dbo.Permissions", "PermissionUser_Id", "dbo.PermissionUsers", "Id");
            //AddForeignKey("dbo.AspNetUsers", "PermissionUser_Id", "dbo.PermissionUsers", "Id");
        }
    }
}
