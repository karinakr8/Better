using Better.Domain.Entities;
using Better.Domain.Models;
using Better.Repositories;
using Better.Repositories.Interfaces;
using Moq;

namespace Better.Tests.RepositoriesTests
{
    public class BetRepositoryTests
    {
        private static readonly Mock<IHelper> _helper = new();
        private static readonly Mock<IRepositoriesValidator> _validator = new();
        private static readonly BetRepository _betRepository = new(_helper.Object, _validator.Object);

        [Fact]
        public void BetRepository_AddBet_ThrowsExceptionBecauseOfValidationError()
        {
            _validator.Setup(v => v.ValidateBet(It.IsAny<BetRequest>())).Throws(new Exception());

            var exception = Assert.Throws<Exception>(() => _betRepository.AddBet(It.IsAny<BetRequest>()));
        }

        [Fact]
        public void BetRepository_AddBet_ThrowsExceptionBecauseOfGettingEventsFromFileError()
        {
            _helper.Setup(h => h.GetAllEventsFromFile()).Throws(new Exception());

            var exception = Assert.Throws<Exception>(() => _betRepository.AddBet(It.IsAny<BetRequest>()));
        }

        [Fact]
        public void BetRepository_AddBet_ThrowsExceptionBecauseOfGettingPlayersFromFileError()
        {
            var betRequest = Entries.BetRequestTest();
            var events = new List<Event> { Entries.EventTest() };

            _helper.Setup(h => h.GetAllEventsFromFile()).Returns(events);
            _helper.Setup(h => h.GetAllPlayersFromFile()).Throws(new Exception());

            var exception = Assert.Throws<Exception>(() => _betRepository.AddBet(betRequest));
        }

        [Fact]
        public void BetRepository_AddBet_ThrowsExceptionBecauseOfUpdateObjectInFileError()
        {
            var betRequest = Entries.BetRequestTest();
            var events = new List<Event> { Entries.EventTest() };
            var players = new List<Player> { Entries.PlayerTest() };

            _helper.Setup(h => h.GetAllEventsFromFile()).Returns(events);
            _helper.Setup(h => h.GetAllPlayersFromFile()).Returns(players);
            _helper.Setup(h => h.UpdatePlayerFile(It.IsAny<Player>(), It.IsAny<Player>())).Throws(new Exception());

            var exception = Assert.Throws<Exception>(() => _betRepository.AddBet(betRequest));
        }

        [Fact]
        public void BetRepository_AddBet_ThrowsExceptionBecauseOfSaveBetToFileError()
        {
            var betRequest = Entries.BetRequestTest();
            var events = new List<Event> { Entries.EventTest() };
            var players = new List<Player> { Entries.PlayerTest() };

            _helper.Setup(h => h.GetAllEventsFromFile()).Returns(events);
            _helper.Setup(h => h.GetAllPlayersFromFile()).Returns(players);
            _helper.Setup(h => h.SaveBetToFile(It.IsAny<Bet>())).Throws(new Exception());

            var exception = Assert.Throws<Exception>(() => _betRepository.AddBet(betRequest));
        }

        [Fact]
        public void BetRepository_AddBet_ReturnsSuccessMessage()
        {
            var betRequest = Entries.BetRequestTest();
            var events = new List<Event> { Entries.EventTest() };
            var players = new List<Player> { Entries.PlayerTest() };

            _helper.Setup(h => h.GetAllEventsFromFile()).Returns(events);
            _helper.Setup(h => h.GetAllPlayersFromFile()).Returns(players);

            var result = _betRepository.AddBet(betRequest);

            Assert.IsType<string>(result);
            Assert.Equal("Bet was successfully placed.", result);
        }

        [Fact]
        public void BetRepository_GetAllBetsLogs_ThrowsExceptionBecauseOfGettingBetsFromFileError()
        {
            _helper.Setup(h => h.GetAllBetsFromFile()).Throws(new Exception());

            var exception = Assert.Throws<Exception>(() => _betRepository.GetAllBetsLogs());
        }

        [Fact]
        public void BetRepository_GetAllBetsLogs_ReturnsBetsLogs()
        {
            var bets = new List<Bet> { Entries.BetTest() };
            var betLogs = new List<BetLog> { Entries.BetLogTest() };

            _helper.Setup(h => h.GetAllBetsFromFile()).Returns(bets);

            var result = _betRepository.GetAllBetsLogs();

            Assert.IsType<List<BetLog>>(result);
            Assert.Single(result);
            Assert.Equal(betLogs.First().BetId, result.First().BetId);
            Assert.Equal(betLogs.First().EventId, result.First().EventId);
            Assert.Equal(betLogs.First().OddId, result.First().OddId);
            Assert.Equal(betLogs.First().ResultCode, result.First().ResultCode);
        }
    }
}
