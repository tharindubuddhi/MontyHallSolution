using MontyHall.Service.Dto;

namespace MontyHall.Service.IServices
{
    public interface IWinStragyService
    {
        bool GetWinResult(bool changeDoor, int selectedDoor, int carDoor);
    }
}
