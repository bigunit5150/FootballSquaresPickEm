namespace FSPE.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scheduleupload : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Team", "City", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Team", "City", c => c.String(nullable: false));
        }
    }
}
