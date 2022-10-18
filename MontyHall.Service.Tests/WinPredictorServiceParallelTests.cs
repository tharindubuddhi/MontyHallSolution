using MontyHall.Service.IServices;
using MontyHall.Service.Services;
using Moq;

namespace MontyHall.Service.Tests
{
    public class WinPredictorServiceParallelTests
    {

        [Fact]
        public async void WinPredictorServiceParallel_When_Zero_Games()
        {
            var winStrategyService = new Mock<IWinStragyService>();
            var winPredictorServiceInstance = new WinPredictorServiceSequential(winStrategyService.Object);
            var result = await winPredictorServiceInstance.GetWinPredictionsAsync(0, true);
            Assert.Equal(0, result.NumberOfGames);
            Assert.Equal(0, result.NumberOfWins);
            Assert.Equal(0, result.NumberOfLooses);
            Assert.Equal(0, result.WinPercentage);
        }

        [Theory]
        [InlineData(5000)]
        [InlineData(10000)]
        [InlineData(1000000)]
        public async void WinPredictorServiceParallel_When_N_Games_With_SwitchDoor(int numberOfGames)
        {
            var winStrategyService = new MontyHallWinStrategyService();
            var winPredictorServiceInstance = new WinPredictorServiceSequential(winStrategyService);
            var result = await winPredictorServiceInstance.GetWinPredictionsAsync(numberOfGames, true);
            Assert.Equal(numberOfGames, result.NumberOfGames);
            Assert.True(result.NumberOfWins > result.NumberOfLooses);
            Assert.True(result.WinPercentage >= 66);
        }

        [Theory]
        [InlineData(5000)]
        [InlineData(10000)]
        [InlineData(1000000)]
        public async void WinPredictorServiceParallel_When_N_Games_With_NO_SwitchDoor(int numberOfGames)
        {
            var winStrategyService = new MontyHallWinStrategyService();
            var winPredictorServiceInstance = new WinPredictorServiceSequential(winStrategyService);
            var result = await winPredictorServiceInstance.GetWinPredictionsAsync(numberOfGames, false);
            Assert.Equal(numberOfGames, result.NumberOfGames);
            Assert.True(result.NumberOfWins < result.NumberOfLooses);
            Assert.True(result.WinPercentage <= 66);
        }
    }
}
