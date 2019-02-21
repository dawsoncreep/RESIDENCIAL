namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class versionInicialBD : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "HuellaDigital");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "HuellaDigital", c => c.String());
        }
    }
}
