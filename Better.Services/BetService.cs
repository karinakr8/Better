﻿using Better.Domain.Models;
using Better.Repositories.Interfaces;
using Better.Services.Interfaces;

namespace Better.Services
{
    public class BetService : IBetService
    {
        private readonly IBetRepository _betRepository;
        private readonly IServicesValidator _validator;

        public BetService(IBetRepository betRepository, IServicesValidator validator)
        {
            _betRepository = betRepository;
            _validator = validator;
        }

        public string AddBet(BetRequest betRequest)
        {
            _validator.ValidateBet(betRequest);

            return _betRepository.AddBet(betRequest);
        }

        public List<BetLog> GetAllBetsLogs() => _betRepository.GetAllBetsLogs();
    }
}
