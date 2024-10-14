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
                                    INSERT INTO public.payment_method(id, name) VALUES
                                        (1, 'Credit Card'),
                                        (2, 'Debit Card'),
                                        (3, 'Bank Transfer'),
                                        (4, 'Cash');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM public.payment_method");
        }
    }
}
