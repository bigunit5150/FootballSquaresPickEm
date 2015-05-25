namespace FSPE.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poolfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Square", "PoolId", "dbo.Pool");
            DropIndex("dbo.Square", new[] { "PoolId" });
            RenameColumn(table: "dbo.Square", name: "PoolId", newName: "Pool_PoolId");
            AlterColumn("dbo.Square", "Pool_PoolId", c => c.Int());
            CreateIndex("dbo.Square", "Pool_PoolId");
            AddForeignKey("dbo.Square", "Pool_PoolId", "dbo.Pool", "PoolId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Square", "Pool_PoolId", "dbo.Pool");
            DropIndex("dbo.Square", new[] { "Pool_PoolId" });
            AlterColumn("dbo.Square", "Pool_PoolId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Square", name: "Pool_PoolId", newName: "PoolId");
            CreateIndex("dbo.Square", "PoolId");
            AddForeignKey("dbo.Square", "PoolId", "dbo.Pool", "PoolId", cascadeDelete: true);
        }
    }
}
