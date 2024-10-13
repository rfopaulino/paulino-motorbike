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
            builder.Property(x => x.CreatedDate).HasColumnType("timestamptz").IsRequired();
            builder.Property(x => x.Number).HasColumnType("varchar(20)").IsRequired();

            builder.HasOne<CNHType>()
                .WithMany()
                .HasForeignKey(x => x.CNHTypeId)
                .IsRequired();

            builder.HasOne<Document>()
                .WithMany()
                .HasForeignKey(x => x.DocumentId)
                .IsRequired();
        }
    }
}
