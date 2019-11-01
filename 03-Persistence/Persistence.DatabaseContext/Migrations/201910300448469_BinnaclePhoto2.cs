namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BinnaclePhoto2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BinnaclePhotoes", "Image", c => c.String());
            AddColumn("dbo.BinnaclePhotoes", "Binnacle_Id", c => c.Int());
            AddColumn("dbo.BinnaclePhotoes", "BinnaclePhotoType_Id", c => c.Int());
            AddColumn("dbo.BinnaclePhotoes", "ExternalBinnacle_Id", c => c.Int());
            CreateIndex("dbo.BinnaclePhotoes", "Binnacle_Id");
            CreateIndex("dbo.BinnaclePhotoes", "BinnaclePhotoType_Id");
            CreateIndex("dbo.BinnaclePhotoes", "ExternalBinnacle_Id");
            AddForeignKey("dbo.BinnaclePhotoes", "Binnacle_Id", "dbo.Binnacles", "Id");
            AddForeignKey("dbo.BinnaclePhotoes", "BinnaclePhotoType_Id", "dbo.BinnaclePhotoTypes", "Id");
            AddForeignKey("dbo.BinnaclePhotoes", "ExternalBinnacle_Id", "dbo.ExternalBinnacles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BinnaclePhotoes", "ExternalBinnacle_Id", "dbo.ExternalBinnacles");
            DropForeignKey("dbo.BinnaclePhotoes", "BinnaclePhotoType_Id", "dbo.BinnaclePhotoTypes");
            DropForeignKey("dbo.BinnaclePhotoes", "Binnacle_Id", "dbo.Binnacles");
            DropIndex("dbo.BinnaclePhotoes", new[] { "ExternalBinnacle_Id" });
            DropIndex("dbo.BinnaclePhotoes", new[] { "BinnaclePhotoType_Id" });
            DropIndex("dbo.BinnaclePhotoes", new[] { "Binnacle_Id" });
            DropColumn("dbo.BinnaclePhotoes", "ExternalBinnacle_Id");
            DropColumn("dbo.BinnaclePhotoes", "BinnaclePhotoType_Id");
            DropColumn("dbo.BinnaclePhotoes", "Binnacle_Id");
            DropColumn("dbo.BinnaclePhotoes", "Image");
        }
    }
}
