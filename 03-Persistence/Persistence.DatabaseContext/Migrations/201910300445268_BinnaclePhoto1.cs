namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BinnaclePhoto1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Binnacles", "BinnaclePhoto_Id", "dbo.BinnaclePhotoes");
            DropIndex("dbo.Binnacles", new[] { "BinnaclePhoto_Id" });
            DropColumn("dbo.Binnacles", "BinnaclePhoto_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Binnacles", "BinnaclePhoto_Id", c => c.Int());
            CreateIndex("dbo.Binnacles", "BinnaclePhoto_Id");
            AddForeignKey("dbo.Binnacles", "BinnaclePhoto_Id", "dbo.BinnaclePhotoes", "Id");
        }
    }
}
