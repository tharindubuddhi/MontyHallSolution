using MontyHall.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall.Service.Services
{
    public class MontyHallWinStrategyService : IWinStragyService
    {
        public bool GetWinResult(bool changeDoor, int selectedDoor, int carDoor)
        {
            bool isWinningRound = false;

            var options = new HashSet<int>() { 0, 1, 2 };

            var hostOpenedDoor = options.Except(new HashSet<int>() { carDoor, selectedDoor }).First();

            var remainingDoor = options.Except(new HashSet<int>() { selectedDoor, hostOpenedDoor }).First();


            if (changeDoor)
            {
                isWinningRound = remainingDoor == carDoor;
            }
            else
            {
                isWinningRound = carDoor == selectedDoor;
            }

            return isWinningRound;
        }
    }
}
