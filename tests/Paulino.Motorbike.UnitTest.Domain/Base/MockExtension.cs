using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using Paulino.Motorbike.Infra.Data.EF;

namespace Paulino.Motorbike.UnitTest.Domain.Base
{
    public static class MockExtension
    {
        public static void MockTransaction(this Mock<IApplicationDbContext> dbContext, Mock<IDbContextTransaction> transactionMock)
        {
            dbContext.Setup(c => c.BeginTransaction()).Returns(transactionMock.Object);
            transactionMock.Setup(t => t.Commit()).Verifiable();
            transactionMock.Setup(t => t.Rollback()).Verifiable();
        }
    }
}
