namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BinnaclePhotoType1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExternalBinnaclePhotoes", "PhotoType_Id", "dbo.PhotoTypes");
            DropIndex("dbo.ExternalBinnaclePhotoes", new[] { "PhotoType_Id" });
            AddColumn("dbo.ExternalBinnaclePhotoes", "BinnaclePhotoType_Id", c => c.Int());
            CreateIndex("dbo.ExternalBinnaclePhotoes", "BinnaclePhotoType_Id");
            AddForeignKey("dbo.ExternalBinnaclePhotoes", "BinnaclePhotoType_Id", "dbo.BinnaclePhotoTypes", "Id");
            DropColumn("dbo.ExternalBinnaclePhotoes", "PhotoType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExternalBinnaclePhotoes", "PhotoType_Id", c => c.Int());
            DropForeignKey("dbo.ExternalBinnaclePhotoes", "BinnaclePhotoType_Id", "dbo.BinnaclePhotoTypes");
            DropIndex("dbo.ExternalBinnaclePhotoes", new[] { "BinnaclePhotoType_Id" });
            DropColumn("dbo.ExternalBinnaclePhotoes", "BinnaclePhotoType_Id");
            CreateIndex("dbo.ExternalBinnaclePhotoes", "PhotoType_Id");
            AddForeignKey("dbo.ExternalBinnaclePhotoes", "PhotoType_Id", "dbo.PhotoTypes", "Id");
        }
    }
}
