using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using FSPE.API.DAL;
using FSPE.API.DAL.Models;
using Excel;

namespace FSPE.API.Utilities
{
    public class ScheduleLoader
    {
        public static void Load(string filename)
        {
            var dbContext = new PoolManagerContext();

            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException("Must pass file name");

            var rows = Workbook.Worksheets(filename).First().Rows;

            var teamNames = (from row in rows
                         select new { Name = row.Cells[0].Text }).Distinct();

            var teams = teamNames.Select(team => dbContext.Teams.Add(new Team() {League = League.NFL, Name = team.Name})).ToList();

            dbContext.SaveChanges();

            var q = from row in rows
                select new Game
                {
                    League = League.NFL,
                    AwayTeam = teams.First( t => t.Name == row.Cells[0].Text),
                    HomeTeam = teams.First( t => t.Name == row.Cells[1].Text.Substring(1)),
                    Week = int.Parse(row.Cells[2].Text.Substring(4)),
                    GameTime = ProcessDate (row.Cells[4].Text,row.Cells[5].Text)

                };

            dbContext.Games.AddRange(q.AsEnumerable());

            dbContext.SaveChanges();
        }

        private static DateTime ProcessDate(string date, string time)
        {
            var dateTime = string.Format("{0} {1}", date, time);
            var parts = dateTime.Split(' ');
            var gameDate = ("January" == parts[0]) ? "2016" : "2015";
            var formatedDatetime = string.Format("{0} {1} {2} {3} {4}", parts[0], parts[1].Substring(0, parts[1].Length - 2), gameDate, parts[2], parts[3]);
            return DateTime.Parse(formatedDatetime).AddHours(-3).ToUniversalTime();
        }
    }
}