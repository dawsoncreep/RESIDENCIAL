namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoType_11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExternalBinnaclePhotoes", "PhotoType_Id", c => c.Int());
            CreateIndex("dbo.ExternalBinnaclePhotoes", "PhotoType_Id");
            AddForeignKey("dbo.ExternalBinnaclePhotoes", "PhotoType_Id", "dbo.PhotoTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExternalBinnaclePhotoes", "PhotoType_Id", "dbo.PhotoTypes");
            DropIndex("dbo.ExternalBinnaclePhotoes", new[] { "PhotoType_Id" });
            DropColumn("dbo.ExternalBinnaclePhotoes", "PhotoType_Id");
        }
    }
}
