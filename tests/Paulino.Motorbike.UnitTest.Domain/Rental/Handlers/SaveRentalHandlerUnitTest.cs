using Moq;
using Paulino.Motorbike.Domain.Rental.Handlers;
using Paulino.Motorbike.Infra.CrossCutting.Exceptions;
using Paulino.Motorbike.Infra.Data.Dapper.Base;
using Paulino.Motorbike.Infra.Data.EF;
using Paulino.Motorbike.UnitTest.Domain.Rental.Requests;

namespace Paulino.Motorbike.UnitTest.Domain.Rental.Handlers
{
    public class SaveRentalHandlerUnitTest
    {
        private readonly Mock<IApplicationDbContext> _dbContextMock;
        private readonly Mock<IDapperRepository> _dapperMock;

        private readonly SaveRentalHandler _handler;

        public SaveRentalHandlerUnitTest()
        {
            _dbContextMock = new Mock<IApplicationDbContext>();
            _dapperMock = new Mock<IDapperRepository>();

            _handler = new SaveRentalHandler(_dbContextMock.Object, _dapperMock.Object);
        }

        [Fact]
        public async Task Success()
        {
            var request = new SaveRentalRequestBuilder()
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.True(result.IsSuccess);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task Invalid_MotorbikeId(int motorbikeId)
        {
            var request = new SaveRentalRequestBuilder()
                .ChangeMotorbikeId(motorbikeId)
                .Build();

            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(request, CancellationToken.None));

            Assert.IsType<ValidationException>(exception);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task Invalid_DriverId(int motorbikeId)
        {
            var request = new SaveRentalRequestBuilder()
                .ChangeDriverId(motorbikeId)
                .Build();

            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(request, CancellationToken.None));

            Assert.IsType<ValidationException>(exception);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task Invalid_PlanId(int motorbikeId)
        {
            var request = new SaveRentalRequestBuilder()
                .ChangePlanId(motorbikeId)
                .Build();

            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(request, CancellationToken.None));

            Assert.IsType<ValidationException>(exception);
        }
    }
}
