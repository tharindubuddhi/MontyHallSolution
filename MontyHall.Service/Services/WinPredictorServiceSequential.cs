using MontyHall.Service.Dto;
using MontyHall.Service.IServices;

namespace MontyHall.Service.Services
{
    public class WinPredictorServiceSequential : IWinPredictorService
    {
        private readonly IWinStragyService _winStragyService;

        public WinPredictorServiceSequential(IWinStragyService winStragyService)
        {
            _winStragyService = winStragyService;
        }

        public async Task<WinPredictorResultDto> GetWinPredictionsAsync(long numberOfGames, bool changeDoor)
        {
            Random random = new Random();
            long winningCount = 0;

            for (long i = 0; i < numberOfGames; i++)
            {
                bool result = _winStragyService.GetWinResult(changeDoor, random.Next(3), random.Next(3));

                if (result) winningCount++;
            }

            await Task.CompletedTask;

            return new WinPredictorResultDto
            {
                NumberOfGames = numberOfGames,
                NumberOfWins = winningCount,
                NumberOfLooses = numberOfGames - winningCount,
                WinPercentage = numberOfGames == 0 ? 0 : Math.Round((decimal)winningCount * 100 / numberOfGames, 2)
            };
        }
    }
}
