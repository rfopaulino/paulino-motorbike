using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Infra.Data.EF.Mapping
{
    public class DocumentDriverMap : IEntityTypeConfiguration<DocumentDriver>
    {
        public void Configure(EntityTypeBuilder<DocumentDriver> builder)
        {
            builder.ToTable(nameof(DocumentDriver));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnType("timestamptz").IsRequired();

            builder.HasOne<Driver>()
                .WithMany()
                .HasForeignKey(x => x.DriverId)
                .IsRequired();

            builder.HasOne<Document>()
                .WithMany()
                .HasForeignKey(x => x.DocumentId)
                .IsRequired();
        }
    }
}
