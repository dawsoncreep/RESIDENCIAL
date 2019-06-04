namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePermissionIdFromPermissionRoles : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PermissionRoles", new[] { "Permission_Id1" });
            DropColumn("dbo.PermissionRoles", "Permission_Id");
            RenameColumn(table: "dbo.PermissionRoles", name: "Permission_Id1", newName: "Permission_Id");
            AlterColumn("dbo.PermissionRoles", "Permission_Id", c => c.Int());
            CreateIndex("dbo.PermissionRoles", "Permission_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PermissionRoles", new[] { "Permission_Id" });
            AlterColumn("dbo.PermissionRoles", "Permission_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.PermissionRoles", name: "Permission_Id", newName: "Permission_Id1");
            AddColumn("dbo.PermissionRoles", "Permission_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.PermissionRoles", "Permission_Id1");
        }
    }
}
