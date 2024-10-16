using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Infra.Data.EF.Mapping
{
    public class RentalPaymentMap : IEntityTypeConfiguration<RentalPayment>
    {
        public void Configure(EntityTypeBuilder<RentalPayment> builder)
        {
            builder.ToTable(nameof(RentalPayment));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnType("timestamptz").IsRequired().HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Property(x => x.Amount).HasColumnType("decimal(16,4)").IsRequired();
            builder.Property(x => x.PaymentMethodId).HasColumnType("integer").IsRequired();
            builder.Property(x => x.RentalId).HasColumnType("integer").IsRequired();

            builder.HasOne(x => x.PaymentMethod)
                .WithMany()
                .HasForeignKey(x => x.PaymentMethodId);

            builder.HasOne(x => x.Rental)
                .WithMany()
                .HasForeignKey(x => x.RentalId);
        }
    }
}
