using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FSPE.API.DAL.Models
{
    public class Pool
    {
        public int PoolId { get; set; }
        [Required]
        public String Name { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public Decimal PricePerSquare { get; set; }

        public int FirstQuarterPayOut { get; set; }

        public int SecondQuaterPayOut { get; set; }

        public int ThirdQuaterPayOut { get; set; }

        public int FourthquaterPayOut { get; set; }

        public int FinalPayOut { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<Square> Squares { get; set; }
    }
}