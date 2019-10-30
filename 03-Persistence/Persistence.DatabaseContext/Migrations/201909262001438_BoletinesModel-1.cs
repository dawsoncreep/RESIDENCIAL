namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoletinesModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bulletins", "DateCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Bulletins", "DateCreateed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bulletins", "DateCreateed", c => c.DateTime(nullable: false));
            DropColumn("dbo.Bulletins", "DateCreated");
        }
    }
}
