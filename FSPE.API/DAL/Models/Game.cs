using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSPE.API.DAL.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public League League { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public DateTime GameTime { get; set; }
        public int Week { get; set; }
        public int? FirstQuaterHomeScore { get; set; }
        public int? FirstQuaterAwayScore { get; set; }
        public int? SecondQuaterHomeScore { get; set; }
        public int? SecondQuaterAwayScore { get; set; }
        public int? ThirdQuaterHomeScore { get; set; }
        public int? ThirdQuaterAwayScore { get; set; }
        public int? FourthQuaterAwayScore { get; set; }
        public int? FourthQuaterHomeScore { get; set; }
        public int? FinalHomeScore { get; set; }
        public int? FinalAwayScore { get; set; }
    }
}