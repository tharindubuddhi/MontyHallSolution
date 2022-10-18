using MontyHall.Service.Dto;
using MontyHall.Service.IServices;

namespace MontyHall.Service.Services
{
    public class WinPredictorServiceParallel : IWinPredictorService
    {

        private readonly IWinStragyService _winStragyService;

        public WinPredictorServiceParallel(IWinStragyService winStragyService)
        {
            _winStragyService = winStragyService;
        }
        public async Task<WinPredictorResultDto> GetWinPredictionsAsync(long numberOfGames, bool changeDoor)
        {
            Random random = new Random();

            const int numParts = 10;
            Task<long>[] numberOfWinsPerLoop = new Task<long>[numParts+1];
            var quotient = (long)Math.Floor((decimal)numberOfGames / numParts);
            var remainder = numberOfGames % numParts;
            for (int i = 0; i <= numParts; i++)
            {
                if (i == numParts)
                {
                    numberOfWinsPerLoop[i] = GetWinPredictionsPerRangeAsync(random, changeDoor, i * quotient + 1, i * quotient + remainder);
                }
                else
                {
                    numberOfWinsPerLoop[i] = GetWinPredictionsPerRangeAsync(random, changeDoor, i * quotient + 1, (i + 1) * quotient);
                }
            }
            var results2 = await Task.WhenAll(numberOfWinsPerLoop);

            var numberOfWins = results2.Sum();

            return new WinPredictorResultDto
            {
                NumberOfGames = numberOfGames,
                NumberOfWins = numberOfWins,
                NumberOfLooses = numberOfGames - numberOfWins,
                WinPercentage = numberOfGames == 0 ? 0 : Math.Round((decimal)numberOfWins * 100 / numberOfGames, 2)
            };
        }

        private async Task<long> GetWinPredictionsPerRangeAsync(Random random,bool changeDoor, long minimum, long maximum)
        {
            
            return await Task.Factory.StartNew(() =>
            {
                long wins = 0;
                for (long i = minimum; i <= maximum; i++)
                {
                    var result = _winStragyService.GetWinResult(changeDoor, random.Next(3), random.Next(3));

                    if (result) wins++;
                }
                return wins;
            });
        }
    }
}
