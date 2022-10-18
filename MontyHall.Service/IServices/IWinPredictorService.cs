using MontyHall.Service.Dto;

namespace MontyHall.Service.IServices
{
    public interface IWinPredictorService
    {
        Task<WinPredictorResultDto> GetWinPredictionsAsync(long numberOfGames, bool changeDoor);
    }
}
