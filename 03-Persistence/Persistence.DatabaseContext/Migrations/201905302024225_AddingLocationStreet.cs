namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingLocationStreet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Street", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "Street");
        }
    }
}
