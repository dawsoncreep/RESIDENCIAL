namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEntityTag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagCode = c.String(nullable: false, maxLength: 255),
                        VehicleBrand = c.String(nullable: false, maxLength: 50),
                        VehicleModel = c.String(nullable: false, maxLength: 50),
                        VehicleYear = c.String(maxLength: 50),
                        Observations = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tags");
        }
    }
}
