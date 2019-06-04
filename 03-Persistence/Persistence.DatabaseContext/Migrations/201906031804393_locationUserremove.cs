namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationUserremove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "LocationUser_Id", "dbo.LocationUsers");
            DropForeignKey("dbo.Locations", "LocationUser_Id", "dbo.LocationUsers");
            DropForeignKey("dbo.LocationUsers", "LocationUserNotification_Id", "dbo.LocationUserNotifications");
            DropIndex("dbo.AspNetUsers", new[] { "LocationUser_Id" });
            DropIndex("dbo.Locations", new[] { "LocationUser_Id" });
            DropIndex("dbo.LocationUsers", new[] { "LocationUserNotification_Id" });
            DropColumn("dbo.AspNetUsers", "LocationUser_Id");
            DropColumn("dbo.Locations", "LocationUser_Id");
            DropTable("dbo.LocationUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LocationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationUserNotification_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Locations", "LocationUser_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "LocationUser_Id", c => c.Int());
            CreateIndex("dbo.LocationUsers", "LocationUserNotification_Id");
            CreateIndex("dbo.Locations", "LocationUser_Id");
            CreateIndex("dbo.AspNetUsers", "LocationUser_Id");
            AddForeignKey("dbo.LocationUsers", "LocationUserNotification_Id", "dbo.LocationUserNotifications", "Id");
            AddForeignKey("dbo.Locations", "LocationUser_Id", "dbo.LocationUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "LocationUser_Id", "dbo.LocationUsers", "Id");
        }
    }
}
