using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Paulino.Motorbike.Infra.Data.EF.Mapping
{
    public class MotorbikeMap : IEntityTypeConfiguration<Entities.Motorbike>
    {
        public void Configure(EntityTypeBuilder<Entities.Motorbike> builder)
        {
            builder.ToTable(nameof(Entities.Motorbike));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnType("timestamptz").IsRequired().HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Property(x => x.Year).HasColumnType("smallint").IsRequired();
            builder.Property(x => x.Model).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Plate).HasColumnType("varchar(10)").IsRequired();
        }
    }
}
