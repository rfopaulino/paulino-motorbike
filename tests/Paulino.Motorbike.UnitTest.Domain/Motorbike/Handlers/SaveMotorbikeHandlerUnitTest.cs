using Paulino.Motorbike.Domain.Motorbike.Handlers;
using Paulino.Motorbike.UnitTest.Domain.Driver.Requests;
using Paulino.Motorbike.UnitTest.Domain.Motorbike.Requests;

namespace Paulino.Motorbike.UnitTest.Domain.Motorbike.Handlers
{
    public class SaveMotorbikeHandlerUnitTest
    {
        private readonly SaveMotorbikeHandler _handler;

        public SaveMotorbikeHandlerUnitTest()
        {
            _handler = new SaveMotorbikeHandler();
        }

        [Fact]
        public async Task Success()
        {
            var request = new SaveMotorbikeRequestBuilder()
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.True(result.IsSuccess);
        }

        [Theory]
        [InlineData(2014)]
        [InlineData(2024)]
        public async Task Valid_Year(int year)
        {
            var request = new SaveMotorbikeRequestBuilder()
                .ChangeYearTo(year)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.True(result.IsSuccess);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(2013)]
        public async Task Invalid_Year(int year)
        {
            var request = new SaveMotorbikeRequestBuilder()
                .ChangeYearTo(year)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task Invalid_Model(string model)
        {
            var request = new SaveMotorbikeRequestBuilder()
                .ChangeModelTo(model)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }

        [Theory]
        [InlineData("0000000")]
        public async Task Valid_Plate(string model)
        {
            var request = new SaveMotorbikeRequestBuilder()
                .ChangePlateTo(model)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.True(result.IsSuccess);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("000000")]
        [InlineData("00000000")]
        public async Task Invalid_Plate(string model)
        {
            var request = new SaveMotorbikeRequestBuilder()
                .ChangePlateTo(model)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }
    }
}
