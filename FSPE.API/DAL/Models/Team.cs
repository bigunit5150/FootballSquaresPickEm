using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSPE.API.DAL.Models
{
    public enum League {  NFL, NCAA}
    public class Team
    {
        public int TeamId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Name { get; set; }
        public League League { get; set; }

        [InverseProperty("AwayTeam")]
        public List<Game> AwayGames { get; set; }
        [InverseProperty("HomeTeam")]
        public List<Game> HomeGames { get; set; }
    }
}