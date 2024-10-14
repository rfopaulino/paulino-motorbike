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
            builder.Property(x => x.CreatedDate).HasColumnType("timestamptz").IsRequired().HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Property(x => x.DriverId).HasColumnType("integer").IsRequired();
            builder.Property(x => x.DocumentId).HasColumnType("integer").IsRequired();

            builder.HasOne(x => x.Driver)
                .WithMany()
                .HasForeignKey(x => x.DriverId);

            builder.HasOne(x => x.Document)
                .WithMany()
                .HasForeignKey(x => x.DocumentId);
        }
    }
}
