using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Paulino.Motorbike.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdaptToReturnAndPayRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "additional_daily",
                table: "plan",
                newName: "additional_daily_amount");

            migrationBuilder.AddColumn<DateTime>(
                name: "closing_date",
                table: "rental",
                type: "timestamptz",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "original_amount",
                table: "rental",
                type: "numeric(16,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "paid_amount",
                table: "rental",
                type: "numeric(16,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "rental_payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    amount = table.Column<decimal>(type: "numeric(16,4)", nullable: false),
                    payment_method_id = table.Column<int>(type: "integer", nullable: false),
                    rental_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rental_payment", x => x.id);
                    table.ForeignKey(
                        name: "FK_rental_payment_payment_method_payment_method_id",
                        column: x => x.payment_method_id,
                        principalTable: "payment_method",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rental_payment_rental_rental_id",
                        column: x => x.rental_id,
                        principalTable: "rental",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rental_payment_payment_method_id",
                table: "rental_payment",
                column: "payment_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_rental_payment_rental_id",
                table: "rental_payment",
                column: "rental_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rental_payment");

            migrationBuilder.DropColumn(
                name: "closing_date",
                table: "rental");

            migrationBuilder.DropColumn(
                name: "original_amount",
                table: "rental");

            migrationBuilder.DropColumn(
                name: "paid_amount",
                table: "rental");

            migrationBuilder.RenameColumn(
                name: "additional_daily_amount",
                table: "plan",
                newName: "additional_daily");
        }
    }
}
