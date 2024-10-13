using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Infra.Data.EF.Mapping
{
    public class DocumentMap : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable(nameof(Document));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnType("timestamptz").IsRequired();
            builder.Property(x => x.Image).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Metadata).HasColumnType("jsonb").IsRequired();

            builder.HasOne<DocumentType>()
                .WithMany()
                .HasForeignKey(x => x.DocumentTypeId)
                .IsRequired();
        }
    }
}
