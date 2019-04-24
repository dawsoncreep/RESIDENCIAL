namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version20190422 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Permissions", "PermissionMasterId_Id", "dbo.Permissions");
            DropIndex("dbo.Permissions", new[] { "PermissionMasterId_Id" });
            DropColumn("dbo.Permissions", "PermissionMasterId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Permissions", "PermissionMasterId_Id", c => c.Int());
            CreateIndex("dbo.Permissions", "PermissionMasterId_Id");
            AddForeignKey("dbo.Permissions", "PermissionMasterId_Id", "dbo.Permissions", "Id");
        }
    }
}
