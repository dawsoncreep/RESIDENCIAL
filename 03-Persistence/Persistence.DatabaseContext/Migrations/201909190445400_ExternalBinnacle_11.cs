namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExternalBinnacle_11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExternalBinnacles", "ExitDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExternalBinnacles", "ExitDate", c => c.DateTime(nullable: false));
        }
    }
}
