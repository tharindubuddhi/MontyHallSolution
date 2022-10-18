using MontyHall.Service.Services;

namespace MontyHall.Service.Tests
{
    public class MontyHallWinStrategyServiceTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void MontyHallWinStrategyService_When_CarDoor_And_Picked_SameDoor_No_Switch(int selectedDoor, int carDoor)
        {
            var montyHallStrategyInstance = new MontyHallWinStrategyService();
            var result = montyHallStrategyInstance.GetWinResult(false, selectedDoor, carDoor);
            Assert.True(result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void MontyHallWinStrategyService_When_CarDoor_And_Picked_SameDoor_With_Switch(int selectedDoor, int carDoor)
        {
            var montyHallStrategyInstance = new MontyHallWinStrategyService();
            var result = montyHallStrategyInstance.GetWinResult(true, selectedDoor, carDoor);
            Assert.False(result);
        }

        [Theory]
        [InlineData(0,1)]
        [InlineData(0, 2)]
        [InlineData(1, 0)]
        [InlineData(1, 2)]
        [InlineData(2, 0)]
        [InlineData(2, 1)]
        public void MontyHallWinStrategyService_When_CarDoor_And_Picked_Different_Door_No_Switch(int selectedDoor, int carDoor)
        {
            var montyHallStrategyInstance = new MontyHallWinStrategyService();
            var result = montyHallStrategyInstance.GetWinResult(false, selectedDoor, carDoor);
            Assert.False(result);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(1, 0)]
        [InlineData(1, 2)]
        [InlineData(2, 0)]
        [InlineData(2, 1)]
        public void MontyHallWinStrategyService_When_CarDoor_And_Picked_Different_Door_With_Switch(int selectedDoor, int carDoor)
        {
            var montyHallStrategyInstance = new MontyHallWinStrategyService();
            var result = montyHallStrategyInstance.GetWinResult(true, selectedDoor, carDoor);
            Assert.True(result);
        }
    }
}
