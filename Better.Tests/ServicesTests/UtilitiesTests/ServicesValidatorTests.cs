namespace Better.Tests.ServicesTests.UtilitiesTests
{
    public class ServicesValidatorTests
    {
        private static readonly Services.Utilities.ServicesValidator _validator = new();

        [Fact]
        public void ServicesValidator_ValidateBet_ThrowsExceptionBecauseBetIsNull()
        {
            var exception = Assert.Throws<ArgumentException>(() => _validator.ValidateBet(null));
            Assert.Equal("Bet parameters were defined incorrectly.", exception.Message);
        }

        [Theory]
        [InlineData(-1.5F)]
        [InlineData(0F)]
        public void ServicesValidator_ValidateBet_ThrowsExceptionBecauseOfInvalidOdd(float odd)
        {
            var betRequest = Entries.BetRequestTest(odd: odd);

            var exception = Assert.Throws<ArgumentException>(() => _validator.ValidateBet(betRequest));
            Assert.Equal("Odds can not have negative or zero value.", exception.Message);
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(0)]
        public void ServicesValidator_ValidateBet_ThrowsExceptionBecauseOfInvalidEventId(int eventId)
        {
            var betRequest = Entries.BetRequestTest(eventId: eventId);

            var exception = Assert.Throws<ArgumentException>(() => _validator.ValidateBet(betRequest));
            Assert.Equal("Ids can not be negative or zero values. Please specify existing values.", exception.Message);
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(0)]
        public void ServicesValidator_ValidateBet_ThrowsExceptionBecauseOfInvalidPlayerId(int playerId)
        {
            var betRequest = Entries.BetRequestTest(playerId: playerId);

            var exception = Assert.Throws<ArgumentException>(() => _validator.ValidateBet(betRequest));
            Assert.Equal("Ids can not be negative or zero values. Please specify existing values.", exception.Message);
        }

        [Theory]
        [InlineData(-20.12F)]
        [InlineData(0F)]
        public void ServicesValidator_ValidateBet_ThrowsExceptionBecauseOfInvalidBetPrice(float betPrice)
        {
            var betRequest = Entries.BetRequestTest(price: betPrice);

            var exception = Assert.Throws<ArgumentException>(() => _validator.ValidateBet(betRequest));
            Assert.Equal("Bet price can not be negative or zero value.", exception.Message);
        }

        [Fact]
        public void ServicesValidator_ValidateBet_DoesNotThrowException()
        {
            var betRequest = Entries.BetRequestTest();

            var exception = Record.Exception(() => _validator.ValidateBet(betRequest));

            Assert.Null(exception);
        }
    }
}
