using Moq;
using Paulino.Motorbike.Domain.Motorbike.Handlers;
using Paulino.Motorbike.Infra.CrossCutting.EventBus;
using Paulino.Motorbike.Infra.CrossCutting.Exception;
using Paulino.Motorbike.Infra.Data.Dapper.Base;
using Paulino.Motorbike.Infra.Data.EF;
using Paulino.Motorbike.UnitTest.Domain.Motorbike.Requests;

namespace Paulino.Motorbike.UnitTest.Domain.Motorbike.Handlers
{
    public class SaveMotorbikeHandlerUnitTest
    {
        private readonly Mock<IApplicationDbContext> _dbContextMock;
        private readonly Mock<IDapperRepository> _dapperMock;
        private readonly Mock<IEventBus> _eventBusMock;

        private readonly SaveMotorbikeHandler _handler;

        public SaveMotorbikeHandlerUnitTest()
        {
            _dbContextMock = new Mock<IApplicationDbContext>();
            _dapperMock = new Mock<IDapperRepository>();
            _eventBusMock = new Mock<IEventBus>();

            _handler = new SaveMotorbikeHandler(_dbContextMock.Object, _dapperMock.Object, _eventBusMock.Object);
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

            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(request, CancellationToken.None));

            Assert.IsType<ValidationException>(exception);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task Invalid_Model(string model)
        {
            var request = new SaveMotorbikeRequestBuilder()
                .ChangeModelTo(model)
                .Build();

            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(request, CancellationToken.None));

            Assert.IsType<ValidationException>(exception);
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

            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(request, CancellationToken.None));

            Assert.IsType<ValidationException>(exception);
        }
    }
}
