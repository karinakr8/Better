using Better.Domain.Entities;
using Better.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Better.Controllers
{
    [Route("/[controller]")]
    public class BetController : Controller
    {
        private readonly IBetService _betService;
        public BetController(IBetService betService)
        {
            _betService = betService;
        }

        // POST: /Bets
        [HttpPost]
        public async Task<IActionResult> AddBet([FromBody] Bet bet) => Ok(await _betService.AddBet(bet));

        // GET: /Bets/Logs
        [HttpGet("/Bets/Logs")]
        public async Task<IActionResult> GetAllBetsLogs() => Ok(await _betService.GetAllBetsLogs());
    }
}
