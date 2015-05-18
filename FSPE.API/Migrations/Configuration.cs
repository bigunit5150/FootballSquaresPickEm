using FSPE.API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace FSPE.API.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<DAL.PoolManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.PoolManagerContext context)
        {
            var teams = new List<Team>
            {
                new Team {Name = "Lions", City = "Detroit", League = League.NFL},
                new Team {Name = "49 ers", City = "San Francisco", League = League.NFL}
            };

            teams.ForEach(t => context.Teams.Add(t))
                ;
            context.SaveChanges();

            var games = new List<Game>
            {
                new Game
                {
                    GameTime = DateTime.Parse("09/08/2013"),
                    HomeTeam = teams[0],
                    AwayTeam = teams[1],
                    League = League.NFL,
                    Week = 1
                }
            };

            games.ForEach(g => context.Games.Add(g));
            context.SaveChanges();

        }
    }
}
