using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Paulino.Motorbike.Infra.Data.EF.Entities;
using System.Text;

namespace Paulino.Motorbike.Infra.Data.EF
{
    public class ApplicationDbContext : DbContext
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
    }
}
