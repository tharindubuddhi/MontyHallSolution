using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall.Service.Dto
{
    public class WinPredictorResultDto
    {
        public long NumberOfGames { get; set; }

        public decimal WinPercentage { get; set; }

        public long NumberOfWins { get; set; }

        public long NumberOfLooses { get; set; }
    }
}
