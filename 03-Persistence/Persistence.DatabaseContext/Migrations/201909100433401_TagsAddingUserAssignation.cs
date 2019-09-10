namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagsAddingUserAssignation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tags", "ApplicationUser_Id");
            AddForeignKey("dbo.Tags", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tags", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Tags", "ApplicationUser_Id");
        }
    }
}
