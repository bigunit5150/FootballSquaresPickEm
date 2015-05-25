namespace FSPE.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixIdentityCreationIssue : DbMigration
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
                        City = c.String(),
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
                        HomePosition = c.Int(nullable: false),
                        VisitorPosition = c.Int(nullable: false),
                        HomeDigit = c.Int(),
                        VisitorDigit = c.Int(),
                        Pool_PoolId = c.Int(),
                    })
                .PrimaryKey(t => t.SquareId)
                .ForeignKey("dbo.Pool", t => t.Pool_PoolId)
                .Index(t => t.Pool_PoolId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        JoinDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Square", "Pool_PoolId", "dbo.Pool");
            DropForeignKey("dbo.Pool", "GameId", "dbo.Game");
            DropForeignKey("dbo.Game", "HomeTeam_TeamId", "dbo.Team");
            DropForeignKey("dbo.Game", "AwayTeam_TeamId", "dbo.Team");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Square", new[] { "Pool_PoolId" });
            DropIndex("dbo.Pool", new[] { "GameId" });
            DropIndex("dbo.Game", new[] { "HomeTeam_TeamId" });
            DropIndex("dbo.Game", new[] { "AwayTeam_TeamId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Square");
            DropTable("dbo.Pool");
            DropTable("dbo.Team");
            DropTable("dbo.Game");
        }
    }
}
