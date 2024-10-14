using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Infra.Data.EF.Mapping
{
    public class RentalMap : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable(nameof(Rental));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnType("timestamptz").IsRequired().HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Property(x => x.StartDate).HasColumnType("timestamptz").IsRequired();
            builder.Property(x => x.EndDate).HasColumnType("timestamptz").IsRequired();
            builder.Property(x => x.ExpectedEndDate).HasColumnType("timestamptz").IsRequired();
            builder.Property(x => x.TotalAmount).HasColumnType("decimal(16,4)").IsRequired();
            builder.Property(x => x.MotorbikeId).HasColumnType("integer").IsRequired();
            builder.Property(x => x.DriverId).HasColumnType("integer").IsRequired();
            builder.Property(x => x.PlanId).HasColumnType("integer").IsRequired();

            builder.HasOne(x => x.Motorbike)
                .WithMany()
                .HasForeignKey(x => x.MotorbikeId);

            builder.HasOne(x => x.Driver)
                .WithMany()
                .HasForeignKey(x => x.DriverId);

            builder.HasOne(x => x.Plan)
                .WithMany()
                .HasForeignKey(x => x.PlanId);
        }
    }
}
