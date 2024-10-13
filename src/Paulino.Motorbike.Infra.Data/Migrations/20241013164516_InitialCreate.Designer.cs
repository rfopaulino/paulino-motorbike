﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Paulino.Motorbike.Infra.Data.EF;

#nullable disable

namespace Paulino.Motorbike.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241013164516_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<int>("DocumentId")
                        .HasColumnType("integer")
                        .HasColumnName("document_id");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("number");

                    b.HasKey("Id");

                    b.HasIndex("CNHTypeId");

                    b.HasIndex("DocumentId");

                    b.ToTable("cnh");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.CNHType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("cnh_type");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("document_type_id");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<string>("Metadata")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("metadata");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.ToTable("document");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.DocumentDriver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<int>("DocumentId")
                        .HasColumnType("integer")
                        .HasColumnName("document_id");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer")
                        .HasColumnName("driver_id");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("DriverId");

                    b.ToTable("document_driver");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("document_type");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birthdate");

                    b.Property<int>("CNHId")
                        .HasColumnType("integer")
                        .HasColumnName("cnh_id");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cnpj");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CNHId");

                    b.ToTable("driver");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.Motorbike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("model");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("plate");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.ToTable("motorbike");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("payment_method");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AdditionalDaily")
                        .HasColumnType("numeric")
                        .HasColumnName("additional_daily");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<decimal>("PercentageFine")
                        .HasColumnType("numeric")
                        .HasColumnName("percentage_fine");

                    b.Property<int>("TermDays")
                        .HasColumnType("integer")
                        .HasColumnName("term_days");

                    b.HasKey("Id");

                    b.ToTable("plan");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer")
                        .HasColumnName("driver_id");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<DateTime>("ExpectedEndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expected_end_date");

                    b.Property<int>("MotorbikeId")
                        .HasColumnType("integer")
                        .HasColumnName("motorbike_id");

                    b.Property<int>("PlanId")
                        .HasColumnType("integer")
                        .HasColumnName("plan_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("MotorbikeId");

                    b.HasIndex("PlanId");

                    b.ToTable("rental");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.RentalFine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("RentalId")
                        .HasColumnType("integer")
                        .HasColumnName("rental_id");

                    b.HasKey("Id");

                    b.HasIndex("RentalId");

                    b.ToTable("rental_fine");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.CNH", b =>
                {
                    b.HasOne("Paulino.Motorbike.Infra.Data.EF.Entities.CNHType", "Type")
                        .WithMany()
                        .HasForeignKey("CNHTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paulino.Motorbike.Infra.Data.EF.Entities.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Paulino.Motorbike.Infra.Data.EF.Entities.Document", b =>
                {
                    b.HasOne("Paulino.Motorbike.Infra.Data.EF.Entities.DocumentType", "Type")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
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
