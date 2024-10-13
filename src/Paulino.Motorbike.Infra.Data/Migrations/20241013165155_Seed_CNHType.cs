using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paulino.Motorbike.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed_CNHType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    INSERT INTO public.cnh_type(id, name, created_date) VALUES
                                        (1, 'A',NOW()),
                                        (2, 'B',NOW()),
                                        (3, 'C',NOW()),
                                        (4, 'D',NOW()),
                                        (5, 'E',NOW()),
                                        (6, 'AB',NOW()),
                                        (7, 'AC',NOW()),
                                        (8, 'AD',NOW()),
                                        (9, 'BC',NOW()),
                                        (10, 'BD', NOW()),
                                        (11, 'CD', NOW()),
                                        (12, 'DE', NOW());");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM public.cnh_type");
        }
    }
}
