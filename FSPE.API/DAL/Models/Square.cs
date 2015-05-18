using System.ComponentModel.DataAnnotations;

namespace FSPE.API.DAL.Models
{
    public class Square
    {
        public int SquareId { get; set; }

        public int PoolId { get; set; }
        public Pool Pool { get; set; }  

        public int HomePosition { get; set; }

        public int VisitorPosition { get; set; }

        public int? HomeDigit { get; set; }

        public int? VisitorDigit { get; set; }
    }
}