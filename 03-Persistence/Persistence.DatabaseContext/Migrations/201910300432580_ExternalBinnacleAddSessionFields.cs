namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExternalBinnacleAddSessionFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExternalBinnacles", "SessionId", c => c.Guid(nullable: false));
            AddColumn("dbo.ExternalBinnacles", "BinnacleType_Id", c => c.Int());
            AddColumn("dbo.ExternalBinnacles", "External_Id", c => c.Int());
            CreateIndex("dbo.ExternalBinnacles", "BinnacleType_Id");
            CreateIndex("dbo.ExternalBinnacles", "External_Id");
            AddForeignKey("dbo.ExternalBinnacles", "BinnacleType_Id", "dbo.BinnacleTypes", "Id");
            AddForeignKey("dbo.ExternalBinnacles", "External_Id", "dbo.Externals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExternalBinnacles", "External_Id", "dbo.Externals");
            DropForeignKey("dbo.ExternalBinnacles", "BinnacleType_Id", "dbo.BinnacleTypes");
            DropIndex("dbo.ExternalBinnacles", new[] { "External_Id" });
            DropIndex("dbo.ExternalBinnacles", new[] { "BinnacleType_Id" });
            DropColumn("dbo.ExternalBinnacles", "External_Id");
            DropColumn("dbo.ExternalBinnacles", "BinnacleType_Id");
            DropColumn("dbo.ExternalBinnacles", "SessionId");
        }
    }
}
