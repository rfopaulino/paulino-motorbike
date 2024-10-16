using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Infra.Data.EF
{
    public interface IApplicationDbContext
    {
        public DbSet<CNH> CNH { get; }
        public DbSet<CNHType> CNHType { get; }
        public DbSet<Document> Document { get; }
        public DbSet<DocumentDriver> DocumentDriver { get; }
        public DbSet<DocumentType> DocumentType { get; }
        public DbSet<Driver> Driver { get; }
        public DbSet<Entities.Motorbike> Motorbike { get; }
        public DbSet<PaymentMethod> PaymentMethod { get; }
        public DbSet<Plan> Plan { get; }
        public DbSet<Rental> Rental { get; }
        public DbSet<RentalFine> RentalFine { get; }
        public DbSet<RentalPayment> RentalPayment { get; }
        public DbSet<Motorbike2024> Motorbike2024 { get; }

        IDbContextTransaction BeginTransaction();
        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;
        Task SaveChangesAsync();
    }
}
