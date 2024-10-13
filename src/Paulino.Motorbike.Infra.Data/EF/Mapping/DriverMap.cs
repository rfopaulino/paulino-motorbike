using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paulino.Motorbike.Infra.Data.EF.Entities;

namespace Paulino.Motorbike.Infra.Data.EF.Mapping
{
    public class DriverMap : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable(nameof(Driver));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnType("timestamptz").IsRequired();
            builder.Property(x => x.Name).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.CNPJ).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Birthdate).HasColumnType("date").IsRequired();

            builder.HasOne<CNH>()
                .WithMany()
                .HasForeignKey(x => x.CNHId)
                .IsRequired();
        }
    }
}
