using Paulino.Motorbike.Domain.Rental.Handlers;
using Paulino.Motorbike.UnitTest.Domain.Rental.Requests;

namespace Paulino.Motorbike.UnitTest.Domain.Rental.Handlers
{
    public class SaveRentalHandlerUnitTest
    {
        private readonly SaveRentalHandler _handler;

        public SaveRentalHandlerUnitTest()
        {
            _handler = new SaveRentalHandler();
        }

        [Fact]
        public async Task Success()
        {
            var request = new SaveRentalRequestBuilder()
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Invalid_Default_StartDate()
        {
            var defaultDate = default(DateTime);

            var request = new SaveRentalRequestBuilder()
                .ChangeStartDateTo(defaultDate)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task Invalid_Default_EndtDate()
        {
            var defaultDate = default(DateTime);

            var request = new SaveRentalRequestBuilder()
                .ChangeEndDateTo(defaultDate)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task Invalid_Default_ExpectedEndtDate()
        {
            var defaultDate = default(DateTime);

            var request = new SaveRentalRequestBuilder()
                .ChangeExpectedEndDateTo(defaultDate)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task Invalid_TotalAmount(decimal totalAmount)
        {
            var request = new SaveRentalRequestBuilder()
                .ChangeTotalAmountTo(totalAmount)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task Invalid_MotorbikeId(int motorbikeId)
        {
            var request = new SaveRentalRequestBuilder()
                .ChangeMotorbikeId(motorbikeId)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task Invalid_DriverId(int motorbikeId)
        {
            var request = new SaveRentalRequestBuilder()
                .ChangeDriverId(motorbikeId)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task Invalid_PlanId(int motorbikeId)
        {
            var request = new SaveRentalRequestBuilder()
                .ChangePlanId(motorbikeId)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }
    }
}
