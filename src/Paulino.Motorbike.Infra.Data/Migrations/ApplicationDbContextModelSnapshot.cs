﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Paulino.Motorbike.Infra.Data.EF;

#nullable disable

namespace Paulino.Motorbike.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.CNH", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CNHTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("cnh_type_id");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int?>("DocumentId")
                        .HasColumnType("integer")
                        .HasColumnName("document_id");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("number");

                    b.HasKey("Id");

                    b.HasIndex("CNHTypeId");

                    b.HasIndex("DocumentId");

                    b.ToTable("cnh", (string)null);
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.CNHType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("cnh_type", (string)null);
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("document_type_id");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("image");

                    b.Property<string>("Metadata")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("metadata");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.ToTable("document", (string)null);
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.DocumentDriver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("DocumentId")
                        .HasColumnType("integer")
                        .HasColumnName("document_id");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer")
                        .HasColumnName("driver_id");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("DriverId");

                    b.ToTable("document_driver", (string)null);
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("document_type", (string)null);
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("date")
                        .HasColumnName("birthdate");

                    b.Property<int>("CNHId")
                        .HasColumnType("integer")
                        .HasColumnName("cnh_id");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("cnpj");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CNHId");

                    b.ToTable("driver", (string)null);
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.Motorbike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("model");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("plate");

                    b.Property<short>("Year")
                        .HasColumnType("smallint")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.ToTable("motorbike", (string)null);
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("payment_method", (string)null);
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AdditionalDaily")
                        .HasColumnType("decimal(16,4)")
                        .HasColumnName("additional_daily");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<decimal>("DailyAmount")
                        .HasColumnType("decimal(16,4)")
                        .HasColumnName("daily_amount");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<decimal>("PercentageFine")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("percentage_fine");

                    b.Property<int>("TermDays")
                        .HasColumnType("integer")
                        .HasColumnName("term_days");

                    b.HasKey("Id");

                    b.ToTable("plan", (string)null);
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer")
                        .HasColumnName("driver_id");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamptz")
                        .HasColumnName("end_date");

                    b.Property<DateTime?>("ExpectedEndDate")
                        .HasColumnType("timestamptz")
                        .HasColumnName("expected_end_date");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("is_active")
                        .HasDefaultValueSql("true");

                    b.Property<int>("MotorbikeId")
                        .HasColumnType("integer")
                        .HasColumnName("motorbike_id");

                    b.Property<int>("PlanId")
                        .HasColumnType("integer")
                        .HasColumnName("plan_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamptz")
                        .HasColumnName("start_date");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(16,4)")
                        .HasColumnName("total_amount");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("MotorbikeId");

                    b.HasIndex("PlanId");

                    b.ToTable("rental", (string)null);
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.RentalFine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(16,4)")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("description");

                    b.Property<int>("RentalId")
                        .HasColumnType("integer")
                        .HasColumnName("rental_id");

                    b.HasKey("Id");

                    b.HasIndex("RentalId");

                    b.ToTable("rental_fine", (string)null);
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.CNH", b =>
                {
                    b.HasOne("Paulino.Motorbike.Infra.Data.EF.Entities.CNHType", "CNHType")
                        .WithMany()
                        .HasForeignKey("CNHTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paulino.Motorbike.Infra.Data.EF.Entities.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId");

                    b.Navigation("CNHType");

                    b.Navigation("Document");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.Document", b =>
                {
                    b.HasOne("Paulino.Motorbike.Infra.Data.EF.Entities.DocumentType", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.DocumentDriver", b =>
                {
                    b.HasOne("Paulino.Motorbike.Infra.Data.EF.Entities.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paulino.Motorbike.Infra.Data.EF.Entities.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.Driver", b =>
                {
                    b.HasOne("Paulino.Motorbike.Infra.Data.EF.Entities.CNH", "CNH")
                        .WithMany()
                        .HasForeignKey("CNHId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CNH");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.Rental", b =>
                {
                    b.HasOne("Paulino.Motorbike.Infra.Data.EF.Entities.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paulino.Motorbike.Infra.Data.EF.Entities.Motorbike", "Motorbike")
                        .WithMany()
                        .HasForeignKey("MotorbikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paulino.Motorbike.Infra.Data.EF.Entities.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Motorbike");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.RentalFine", b =>
                {
                    b.HasOne("Paulino.Motorbike.Infra.Data.EF.Entities.Rental", "Rental")
                        .WithMany()
                        .HasForeignKey("RentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rental");
                });
#pragma warning restore 612, 618
        }
    }
}
