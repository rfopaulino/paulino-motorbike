using Paulino.Motorbike.Domain.Rental.Handlers;
using Paulino.Motorbike.UnitTest.Domain.Rental.Requests;

namespace Paulino.Motorbike.UnitTest.Domain.Rental.Handlers
{
    public class ReturnRentalHandlerUnitTest
    {
        private readonly ReturnRentalHandler _handler;

        public ReturnRentalHandlerUnitTest()
        {
            _handler = new ReturnRentalHandler();
        }

        [Fact]
        public async Task Success()
        {
            var request = new ReturnRentalRequestBuilder()
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.True(result.IsSuccess);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task Invalid_RentalId(int motorbikeId)
        {
            var request = new ReturnRentalRequestBuilder()
                .ChangeRentalIdTo(motorbikeId)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }
    }
}
