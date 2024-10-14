using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Infra.Data.EF.Mapping
{
    public class CNHTypeMap : IEntityTypeConfiguration<CNHType>
    {
        public void Configure(EntityTypeBuilder<CNHType> builder)
        {
            builder.ToTable(nameof(CNHType));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate).HasColumnType("timestamptz").IsRequired().HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnType("varchar(30)").IsRequired();
        }
    }
}
