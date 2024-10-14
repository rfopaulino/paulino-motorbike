using Paulino.Motorbike.Domain.Driver.Handlers;
using Paulino.Motorbike.UnitTest.Domain.Driver.Requests;

namespace Paulino.Motorbike.UnitTest.Domain.Driver.Handlers
{
    public class SaveDriverHandlerUnitTest
    {
        private readonly SaveDriverHandler _handler;

        public SaveDriverHandlerUnitTest()
        {
            _handler = new SaveDriverHandler();
        }

        [Fact]
        public async Task Success()
        {
            var request = new SaveDriverRequestBuilder()
                .Build();

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

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }

        [Theory]
        [InlineData("17.332.947/0001-00")]
        [InlineData("17332947000100")]
        public async Task Valid_CNPJ(string cnpj)
        {
            var request = new SaveDriverRequestBuilder()
                .ChangeCNPJTo(cnpj)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
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

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }

        [Theory]
        [InlineData("42697724491")]
        public async Task Valid_CNH(string cnh)
        {
            var request = new SaveDriverRequestBuilder()
                .ChangeCNHTo(cnh)
                .Build();

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
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

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.False(result.IsSuccess);
        }
    }
}
