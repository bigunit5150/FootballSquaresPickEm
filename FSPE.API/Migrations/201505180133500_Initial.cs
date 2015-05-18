namespace FSPE.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        League = c.Int(nullable: false),
                        GameTime = c.DateTime(nullable: false),
                        Week = c.Int(nullable: false),
                        FirstQuaterHomeScore = c.Int(),
                        FirstQuaterAwayScore = c.Int(),
                        SecondQuaterHomeScore = c.Int(),
                        SecondQuaterAwayScore = c.Int(),
                        ThirdQuaterHomeScore = c.Int(),
                        ThirdQuaterAwayScore = c.Int(),
                        FourthQuaterAwayScore = c.Int(),
                        FourthQuaterHomeScore = c.Int(),
                        FinalHomeScore = c.Int(),
                        FinalAwayScore = c.Int(),
                        AwayTeam_TeamId = c.Int(),
                        HomeTeam_TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.Team", t => t.AwayTeam_TeamId)
                .ForeignKey("dbo.Team", t => t.HomeTeam_TeamId)
                .Index(t => t.AwayTeam_TeamId)
                .Index(t => t.HomeTeam_TeamId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        League = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.Pool",
                c => new
                    {
                        PoolId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        GameId = c.Int(nullable: false),
                        PricePerSquare = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstQuarterPayOut = c.Int(nullable: false),
                        SecondQuaterPayOut = c.Int(nullable: false),
                        ThirdQuaterPayOut = c.Int(nullable: false),
                        FourthquaterPayOut = c.Int(nullable: false),
                        FinalPayOut = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PoolId)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Square",
                c => new
                    {
                        SquareId = c.Int(nullable: false, identity: true),
                        PoolId = c.Int(nullable: false),
                        HomePosition = c.Int(nullable: false),
                        VisitorPosition = c.Int(nullable: false),
                        HomeDigit = c.Int(),
                        VisitorDigit = c.Int(),
                    })
                .PrimaryKey(t => t.SquareId)
                .ForeignKey("dbo.Pool", t => t.PoolId, cascadeDelete: true)
                .Index(t => t.PoolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Square", "PoolId", "dbo.Pool");
            DropForeignKey("dbo.Pool", "GameId", "dbo.Game");
            DropForeignKey("dbo.Game", "HomeTeam_TeamId", "dbo.Team");
            DropForeignKey("dbo.Game", "AwayTeam_TeamId", "dbo.Team");
            DropIndex("dbo.Square", new[] { "PoolId" });
            DropIndex("dbo.Pool", new[] { "GameId" });
            DropIndex("dbo.Game", new[] { "HomeTeam_TeamId" });
            DropIndex("dbo.Game", new[] { "AwayTeam_TeamId" });
            DropTable("dbo.Square");
            DropTable("dbo.Pool");
            DropTable("dbo.Team");
            DropTable("dbo.Game");
        }
    }
}
