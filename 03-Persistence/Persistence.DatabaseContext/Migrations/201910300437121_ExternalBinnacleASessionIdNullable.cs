namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExternalBinnacleASessionIdNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExternalBinnacles", "SessionId", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExternalBinnacles", "SessionId", c => c.Guid(nullable: false));
        }
    }
}
