using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Infra.Data.EF.Mapping
{
    public class PlanMap : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.ToTable(nameof(Plan));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnType("timestamptz").IsRequired();
            builder.Property(x => x.TermDays).HasColumnType("integer").IsRequired();
            builder.Property(x => x.Amount).HasColumnType("decimal(16,4)").IsRequired();
            builder.Property(x => x.AdditionalDaily).HasColumnType("decimal(16,4)").IsRequired();
            builder.Property(x => x.PercentageFine).HasColumnType("decimal(5,2)").IsRequired();
            builder.Property(x => x.IsActive).HasColumnType("boolean").IsRequired();
        }
    }
}
