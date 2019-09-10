namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuditoryFieldsTag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Tags", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Tags", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Tags", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Tags", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Tags", "DeletedBy", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tags", "CreatedBy");
            CreateIndex("dbo.Tags", "UpdatedBy");
            CreateIndex("dbo.Tags", "DeletedBy");
            AddForeignKey("dbo.Tags", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tags", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tags", "UpdatedBy", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tags", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tags", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Tags", new[] { "DeletedBy" });
            DropIndex("dbo.Tags", new[] { "UpdatedBy" });
            DropIndex("dbo.Tags", new[] { "CreatedBy" });
            DropColumn("dbo.Tags", "DeletedBy");
            DropColumn("dbo.Tags", "DeletedAt");
            DropColumn("dbo.Tags", "UpdatedBy");
            DropColumn("dbo.Tags", "UpdatedAt");
            DropColumn("dbo.Tags", "CreatedBy");
            DropColumn("dbo.Tags", "CreatedAt");
        }
    }
}
