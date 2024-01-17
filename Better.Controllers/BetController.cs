using Better.Domain.Entities;
using Better.Domain.Enums;
using Better.Domain.Models;
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
        public IActionResult AddBet([FromBody] BetRequest betRequest)
        {            
            return Ok(_betService.AddBet(betRequest));
        }

        // GET: /Bets/Logs
        [HttpGet("/Bets/Logs")]
        public IActionResult GetAllBetsLogs() => Ok(_betService.GetAllBetsLogs());
    }
}
