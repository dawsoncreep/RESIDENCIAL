namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventTypesTiedToExternalUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventTypes", "IsTiedToExternalUser", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventTypes", "IsTiedToExternalUser");
        }
    }
}
