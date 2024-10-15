using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using Paulino.Motorbike.Domain.Driver.Handlers;
using Paulino.Motorbike.Domain.Enums;
using Paulino.Motorbike.Infra.CrossCutting.Exceptions;
using Paulino.Motorbike.Infra.Data.Dapper.Base;
using Paulino.Motorbike.Infra.Data.EF;
using Paulino.Motorbike.UnitTest.Domain.Base;
using Paulino.Motorbike.UnitTest.Domain.Driver.Requests;

namespace Paulino.Motorbike.UnitTest.Domain.Driver.Handlers
{
    public class SaveDriverHandlerUnitTest
    {
        private readonly Mock<IApplicationDbContext> _dbContextMock;
        private readonly Mock<IDbContextTransaction> _transactionMock;
        private readonly Mock<IDapperRepository> _dapperMock;

        private readonly SaveDriverHandler _handler;

        public SaveDriverHandlerUnitTest()
        {
            _dbContextMock = new Mock<IApplicationDbContext>();
            _transactionMock = new Mock<IDbContextTransaction>();
            _dapperMock = new Mock<IDapperRepository>();

            _handler = new SaveDriverHandler(_dbContextMock.Object, _dapperMock.Object);
        }

        [Fact]
        public async Task Success()
        {
            var request = new SaveDriverRequestBuilder()
                .Build();

            _dbContextMock.MockTransaction(_transactionMock);

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.True(result.IsSuccess);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task Invalid_Name(string name)
        {
            var request = new SaveDriverRequestBuilder()
                .ChangeNameTo(name)
                .Build();

            _dbContextMock.MockTransaction(_transactionMock);

            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(request, CancellationToken.None));

            Assert.IsType<ValidationException>(exception);
        }

        [Theory]
        [InlineData("17.332.947/0001-00")]
        [InlineData("17332947000100")]
        public async Task Valid_CNPJ(string cnpj)
        {
            var request = new SaveDriverRequestBuilder()
                .ChangeCNPJTo(cnpj)
                .Build();

            _dbContextMock.MockTransaction(_transactionMock);

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.True(result.IsSuccess);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("1733294700010")] //13 digits
        [InlineData("173329470001000")] //15 digits
        [InlineData("1733294700010a")] // 14 with letter
        [InlineData("73916528041215")] // 14 invalid
        public async Task Invalid_CNPJ(string cnpj)
        {
            var request = new SaveDriverRequestBuilder()
                .ChangeCNPJTo(cnpj)
                .Build();

            _dbContextMock.MockTransaction(_transactionMock);

            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(request, CancellationToken.None));

            Assert.IsType<ValidationException>(exception);
        }

        [Theory]
        [InlineData("42697724491")]
        public async Task Valid_CNH(string cnh)
        {
            var request = new SaveDriverRequestBuilder()
                .ChangeCNHTo(cnh)
                .Build();

            _dbContextMock.MockTransaction(_transactionMock);

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.True(result.IsSuccess);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("4269772449")] //10 digits
        [InlineData("426977244911")] //12 digits
        [InlineData("4269772449a")] //11 with letter
        [InlineData("58319672481")] //11 invalid
        public async Task Invalid_CNH(string cnh)
        {
            var request = new SaveDriverRequestBuilder()
                .ChangeCNHTo(cnh)
                .Build();

            _dbContextMock.MockTransaction(_transactionMock);

            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(request, CancellationToken.None));

            Assert.IsType<ValidationException>(exception);
        }

        [Theory]
        [InlineData((int)CNHTypeEnum.A)]
        [InlineData((int)CNHTypeEnum.B)]
        [InlineData((int)CNHTypeEnum.AB)]
        public async Task Valid_CNHType(int cnhType)
        {
            var request = new SaveDriverRequestBuilder()
                .ChangeCNHTypeId(cnhType)
                .Build();

            _dbContextMock.MockTransaction(_transactionMock);

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.True(result.IsSuccess);
        }

        [Theory]
        [InlineData((int)CNHTypeEnum.C)]
        [InlineData((int)CNHTypeEnum.D)]
        [InlineData((int)CNHTypeEnum.E)]
        [InlineData((int)CNHTypeEnum.AC)]
        [InlineData((int)CNHTypeEnum.AD)]
        [InlineData((int)CNHTypeEnum.BC)]
        [InlineData((int)CNHTypeEnum.BD)]
        [InlineData((int)CNHTypeEnum.CD)]
        [InlineData((int)CNHTypeEnum.DE)]
        public async Task Invalid_CNHType(int cnhType)
        {
            var request = new SaveDriverRequestBuilder()
                .ChangeCNHTypeId(cnhType)
                .Build();

            _dbContextMock.MockTransaction(_transactionMock);

            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(request, CancellationToken.None));

            Assert.IsType<ValidationException>(exception);
        }
    }
}
