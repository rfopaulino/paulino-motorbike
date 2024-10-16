using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Infra.Data.EF.Mapping
{
    public class Motorbike2024Map : IEntityTypeConfiguration<Motorbike2024>
    {
        public void Configure(EntityTypeBuilder<Motorbike2024> builder)
        {
            builder.ToTable(nameof(Motorbike2024));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnType("timestamptz").IsRequired().HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Property(x => x.EventMessage).HasColumnType("jsonb").IsRequired();
        }
    }
}
