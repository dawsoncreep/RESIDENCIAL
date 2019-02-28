namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTableBinnacleField100 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Binnacles", "Name", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Binnacles", "Name", c => c.String());
        }
    }
}
