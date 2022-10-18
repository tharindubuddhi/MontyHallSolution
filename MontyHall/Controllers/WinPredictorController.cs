using Microsoft.AspNetCore.Mvc;
using MontyHall.Service.Dto;
using MontyHall.Service.IServices;

namespace MontyHall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WinPredictorController : ControllerBase
    {
        private readonly ILogger<WinPredictorController> _logger;
        private readonly IWinPredictorService _winPredictorService;

        public WinPredictorController(IWinPredictorService winPredictorService, ILogger<WinPredictorController> logger)
        {
            _logger = logger;
            _winPredictorService = winPredictorService;
        }

        [HttpGet(Name = "GetResult")]
        public async Task<WinPredictorResultDto> Get(long numberOfGames, bool changeDoor)
        {
            return await _winPredictorService.GetWinPredictionsAsync(numberOfGames, changeDoor);
        }
    }
}