using Better.Domain.Models;
using Better.Repositories.Interfaces;
using Better.Services;
using Moq;

namespace Better.Tests.ServicesTests
{
    public class BetServiceTests
    {
        private static readonly Mock<IBetRepository> _betRepository = new();
        private static readonly Mock<Services.Interfaces.IServicesValidator> _validator = new();
        private static readonly BetService _betService = new(_betRepository.Object, _validator.Object);
        
        [Fact]
        public void BetService_AddBet_ThrowsExceptionBecauseOfFailedValidation()
        {
            var betRequest = Entries.BetRequestTest();

            _validator.Setup(b => b.ValidateBet(betRequest)).Throws(new Exception());

            var exception = Assert.Throws<Exception>(() => _betService.AddBet(betRequest));
        }

        [Fact]
        public void BetService_AddBet_ThrowsExceptionBecauseOfRepositoryError()
        {
            var betRequest = Entries.BetRequestTest();

            _betRepository.Setup(b => b.AddBet(betRequest)).Throws(new Exception());

            var exception = Assert.Throws<Exception>(() => _betService.AddBet(betRequest));
        }        

        [Fact]
        public void BetService_AddBet_ReturnsSuccessMessage()
        {
            var betRequest = Entries.BetRequestTest();

            _betRepository.Setup(b => b.AddBet(betRequest)).Returns("Bet was successfully placed.");

            var result = _betService.AddBet(betRequest);

            Assert.IsType<string>(result);
            Assert.Equal("Bet was successfully placed.", result);
        }

        [Fact]
        public void BetService_GetAllBetsLogs_ThrowsExceptionBecauseOfRepositoryError()
        {
            _betRepository.Setup(b => b.GetAllBetsLogs()).Throws(new Exception());

            var exception = Assert.Throws<Exception>(() => _betService.GetAllBetsLogs());
        }

        [Fact]
        public void BetService_GetAllBetsLogs_ReturnsBetLogsList()
        {
            var betLogs = new List<BetLog> { Entries.BetLogTest() };

            _betRepository.Setup(b => b.GetAllBetsLogs()).Returns(betLogs);

            var result = _betService.GetAllBetsLogs();

            Assert.IsType<List<BetLog>>(result);
            Assert.Equal(betLogs.First().BetId, result.First().BetId);
            Assert.Equal(betLogs.First().EventId, result.First().EventId);
            Assert.Equal(betLogs.First().OddId, result.First().OddId);
            Assert.Equal(betLogs.First().ResultCode, result.First().ResultCode);
        }
    }
}
