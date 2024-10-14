using Paulino.Motorbike.Domain.Motorbike.Handlers;
using Paulino.Motorbike.UnitTest.Domain.Motorbike.Requests;

namespace Paulino.Motorbike.UnitTest.Domain.Motorbike.Handlers
{
    public class EditPlateMotorbikeHandlerUnitTest
    {
        private readonly EditPlateMotorbikeHandler _handler;

        public EditPlateMotorbikeHandlerUnitTest()
        {
            _handler = new EditPlateMotorbikeHandler();
        }

        [Fact]
        public async Task Success()
        {
            var request = new EditPlateMotorbikeRequestBuilder()
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.True(result.IsSuccess);
        }

        [Theory]
        [InlineData("0000000")]
        public async Task Valid_Plate(string plate)
        {
            var request = new EditPlateMotorbikeRequestBuilder()
                .ChangePlateTo(plate)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.True(result.IsSuccess);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("000000")]
        [InlineData("00000000")]
        public async Task Invalid_Plate(string plate)
        {
            var request = new EditPlateMotorbikeRequestBuilder()
                .ChangePlateTo(plate)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task Invalid_MotorbikeId(int motorbikeId)
        {
            var request = new EditPlateMotorbikeRequestBuilder()
                .ChangeMotorbikeId(motorbikeId)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }
    }
}
