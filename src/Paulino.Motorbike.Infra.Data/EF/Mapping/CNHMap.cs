using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Infra.Data.EF.Mapping
{
    public class CNHMap : IEntityTypeConfiguration<CNH>
    {
        public void Configure(EntityTypeBuilder<CNH> builder)
        {
            builder.ToTable(nameof(CNH));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnType("timestamptz").IsRequired().HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Property(x => x.Number).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.CNHTypeId).HasColumnType("integer").IsRequired();
            builder.Property(x => x.DocumentId).HasColumnType("integer").IsRequired(false);

            builder.HasOne(x => x.CNHType)
                .WithMany()
                .HasForeignKey(x => x.CNHTypeId);

            builder.HasOne(x => x.Document)
                .WithMany()
                .HasForeignKey(x => x.DocumentId);
        }
    }
}
