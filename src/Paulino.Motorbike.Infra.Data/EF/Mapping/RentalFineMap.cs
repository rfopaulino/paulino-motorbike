using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Infra.Data.EF.Mapping
{
    public class RentalFineMap : IEntityTypeConfiguration<RentalFine>
    {
        public void Configure(EntityTypeBuilder<RentalFine> builder)
        {
            builder.ToTable(nameof(RentalFine));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnType("timestamptz").IsRequired();
            builder.Property(x => x.Description).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Amount).HasColumnType("decimal(16,4)").IsRequired();

            builder.HasOne<Rental>()
                .WithMany()
                .HasForeignKey(x => x.RentalId)
                .IsRequired();
        }
    }
}
