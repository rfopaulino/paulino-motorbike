using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Infra.Data.EF.Mapping
{
    public class PaymentMethodMap : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable(nameof(PaymentMethod));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate).HasColumnType("timestamptz").IsRequired();
            builder.Property(x => x.Name).HasColumnType("varchar(30)").IsRequired();
        }
    }
}
