namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationUserFix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Location_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LocationUsers", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.LocationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.LocationUsers", new[] { "Location_Id" });
            DropIndex("dbo.LocationUsers", new[] { "ApplicationUser_Id" });
            DropTable("dbo.LocationUsers");
        }
    }
}
