using Better.Repositories.Interfaces;
using Moq;
using Better.Domain.Entities;
using Better.Repositories.Utilities;

namespace Better.Tests.RepositoriesTests.UtilitiesTests
{
    public class RepositoriesValidatorTests
    {
        private static readonly Mock<IHelper> _helper = new();
        private static readonly RepositoriesValidator _validator = new(_helper.Object);

        [Theory]
        [InlineData(12)]
        [InlineData(24)]
        [InlineData(93)]
        public void RepositoriesValidator_ValidateBet_ThrowsExceptionBecauseOfInvalidEvent(int eventId)
        {
            var events = new List<Event> { Entries.EventTest(id: eventId) };
            var betRequest = Entries.BetRequestTest();

            _helper.Setup(h => h.GetAllEventsFromFile()).Returns(events);

            var exception = Assert.Throws<ArgumentException>(() => _validator.ValidateBet(betRequest));
            Assert.Equal("Event does not exist.", exception.Message);
        }

        [Theory]
        [InlineData(3.2F)]
        [InlineData(0.1F)]
        [InlineData(1.7F)]
        public void RepositoriesValidator_ValidateBet_ThrowsExceptionBecauseOfInvalidLiveEventOdd(float odd)
        {
            var events = new List<Event> { Entries.EventTest(isLive: true) };
            var betRequest = Entries.BetRequestTest(odd: odd);

            _helper.Setup(h => h.GetAllEventsFromFile()).Returns(events);

            var exception = Assert.Throws<ArgumentException>(() => _validator.ValidateBet(betRequest));
            Assert.Equal("Defined odd of live event was not accepted.", exception.Message);
        }

        [Theory]
        [InlineData(3.2F)]
        [InlineData(0.1F)]
        [InlineData(1.58F)]
        public void RepositoriesValidator_ValidateBet_ThrowsExceptionBecauseOfInvalidRegularEventOdd(float odd)
        {
            var events = new List<Event> { Entries.EventTest(isLive: false) };
            var betRequest = Entries.BetRequestTest(odd: odd);

            _helper.Setup(h => h.GetAllEventsFromFile()).Returns(events);

            var exception = Assert.Throws<ArgumentException>(() => _validator.ValidateBet(betRequest));
            Assert.Equal("Defined odd of regular event was not accepted.", exception.Message);
        }

        [Theory]
        [InlineData(1112)]
        [InlineData(5248)]
        [InlineData(1000)]
        public void RepositoriesValidator_ValidateBet_ThrowsExceptionBecauseOfInvalidPlayer(int playerId)
        {
            var events = new List<Event> { Entries.EventTest() };
            var players = new List<Player> { Entries.PlayerTest() };
            var betRequest = Entries.BetRequestTest(playerId: playerId);

            _helper.Setup(h => h.GetAllEventsFromFile()).Returns(events);
            _helper.Setup(h => h.GetAllPlayersFromFile()).Returns(players);

            var exception = Assert.Throws<ArgumentException>(() => _validator.ValidateBet(betRequest));
            Assert.Equal("Player does not exist.", exception.Message);
        }

        [Theory]
        [InlineData(50F, 51F)]
        [InlineData(2F, 50F)]
        [InlineData(0F, 1F)]
        public void RepositoriesValidator_ValidateBet_ThrowsExceptionBecauseOfInvalidBalance(float balance, float betPrice)
        {
            var events = new List<Event> { Entries.EventTest() };
            var players = new List<Player> { Entries.PlayerTest(balance: balance) };
            var betRequest = Entries.BetRequestTest(price: betPrice);

            _helper.Setup(h => h.GetAllEventsFromFile()).Returns(events);
            _helper.Setup(h => h.GetAllPlayersFromFile()).Returns(players);

            var exception = Assert.Throws<ArgumentException>(() => _validator.ValidateBet(betRequest));
            Assert.Equal("Player balance is too low.", exception.Message);
        }

        [Fact]
        public void RepositoriesValidator_ValidateBet_DoesNotThrowException()
        {
            var events = new List<Event> { Entries.EventTest() };
            var players = new List<Player> { Entries.PlayerTest() };
            var betRequest = Entries.BetRequestTest();

            _helper.Setup(h => h.GetAllEventsFromFile()).Returns(events);
            _helper.Setup(h => h.GetAllPlayersFromFile()).Returns(players);

            var exception = Record.Exception(() => _validator.ValidateBet(betRequest));

            Assert.Null(exception);
        }
    }
}
