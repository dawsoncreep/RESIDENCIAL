namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingPermissionId_TointroduceForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PermissionUsers", "Permission_Id", "dbo.Permissions");
            DropIndex("dbo.PermissionUsers", new[] { "Permission_Id" });
            AlterColumn("dbo.PermissionUsers", "Permission_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.PermissionUsers", "Permission_Id");
            AddForeignKey("dbo.PermissionUsers", "Permission_Id", "dbo.Permissions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PermissionUsers", "Permission_Id", "dbo.Permissions");
            DropIndex("dbo.PermissionUsers", new[] { "Permission_Id" });
            AlterColumn("dbo.PermissionUsers", "Permission_Id", c => c.Int());
            CreateIndex("dbo.PermissionUsers", "Permission_Id");
            AddForeignKey("dbo.PermissionUsers", "Permission_Id", "dbo.Permissions", "Id");
        }
    }
}
