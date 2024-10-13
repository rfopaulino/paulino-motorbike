using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paulino.Motorbike.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Plans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    INSERT INTO public.plan(term_days, amount, additional_daily, percentage_fine, is_active, created_date) VALUES
                                        (7, 30, 50, 0.2, true, NOW()),
                                        (15, 28, 50, 0.4, true, NOW()),
                                        (30, 22, 40, 0, true, NOW()),
                                        (45, 20, 50, 0, true, NOW()),
                                        (50, 18, 50, 0, true, NOW());");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM public.plan");
        }
    }
}
