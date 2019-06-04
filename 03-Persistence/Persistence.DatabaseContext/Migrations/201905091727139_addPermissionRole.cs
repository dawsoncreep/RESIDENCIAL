namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPermissionRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PermissionRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Permission_Id = c.Int(nullable: false),
                        ApplicationRole_Id = c.String(maxLength: 128),
                        Permission_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetRoles", t => t.ApplicationRole_Id)
                .ForeignKey("dbo.Permissions", t => t.Permission_Id1)
                .Index(t => t.ApplicationRole_Id)
                .Index(t => t.Permission_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PermissionRoles", "Permission_Id1", "dbo.Permissions");
            DropForeignKey("dbo.PermissionRoles", "ApplicationRole_Id", "dbo.AspNetRoles");
            DropIndex("dbo.PermissionRoles", new[] { "Permission_Id1" });
            DropIndex("dbo.PermissionRoles", new[] { "ApplicationRole_Id" });
            DropTable("dbo.PermissionRoles");
        }
    }
}
