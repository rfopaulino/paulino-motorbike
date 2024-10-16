using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Paulino.Motorbike.Infra.Data.EF.Entities;
using Paulino.Motorbike.Infra.Data.EF.Mapping;
using System.Text;

namespace Paulino.Motorbike.Infra.Data.EF
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CNHMap());
            modelBuilder.ApplyConfiguration(new CNHTypeMap());
            modelBuilder.ApplyConfiguration(new DocumentDriverMap());
            modelBuilder.ApplyConfiguration(new DocumentMap());
            modelBuilder.ApplyConfiguration(new DocumentTypeMap());
            modelBuilder.ApplyConfiguration(new DriverMap());
            modelBuilder.ApplyConfiguration(new MotorbikeMap());
            modelBuilder.ApplyConfiguration(new PaymentMethodMap());
            modelBuilder.ApplyConfiguration(new PlanMap());
            modelBuilder.ApplyConfiguration(new RentalFineMap());
            modelBuilder.ApplyConfiguration(new RentalMap());
            modelBuilder.ApplyConfiguration(new RentalPaymentMap());

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(ConvertToUnderscore(entity.GetTableName()));

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(ConvertToUnderscore(property.Name));
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        private string ConvertToUnderscore(string name)
        {
            var result = new StringBuilder();

            for (int i = 0; i < name.Length; i++)
            {
                char c = name[i];
                if (i > 0 && i + 1 < name.Length && char.IsUpper(c) && char.IsLower(name[i + 1]))
                {
                    result.Append('_');
                }
                result.Append(c);
            }

            return result.ToString().ToLower();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return base.Database.BeginTransaction();
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await Set<TEntity>().AddAsync(entity);
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        public DbSet<CNH> CNH { get; set; }
        public DbSet<CNHType> CNHType { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<DocumentDriver> DocumentDriver { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Entities.Motorbike> Motorbike { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<RentalFine> RentalFine { get; set; }
        public DbSet<RentalPayment> RentalPayment { get; set; }
    }
}
