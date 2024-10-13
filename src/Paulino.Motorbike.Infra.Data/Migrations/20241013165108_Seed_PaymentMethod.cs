using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paulino.Motorbike.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed_PaymentMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    INSERT INTO public.payment_method(id, name, created_date) VALUES
                                        (1, 'Credit Card', NOW()),
                                        (2, 'Debit Card', NOW()),
                                        (3, 'Bank Transfer', NOW()),
                                        (4, 'Cash', NOW());");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM public.payment_method");
        }
    }
}
