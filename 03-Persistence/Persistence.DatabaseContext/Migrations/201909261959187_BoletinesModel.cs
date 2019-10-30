namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoletinesModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bulletins", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Bulletins", "Description", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Bulletins", "DateCreateed", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bulletins", "DateCreateed");
            DropColumn("dbo.Bulletins", "Description");
            DropColumn("dbo.Bulletins", "Name");
        }
    }
}
