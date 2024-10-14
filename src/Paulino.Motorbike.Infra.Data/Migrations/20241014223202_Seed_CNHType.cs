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
                                    INSERT INTO public.cnh_type(id, name) VALUES
                                        (1, 'A'),
                                        (2, 'B'),
                                        (3, 'C'),
                                        (4, 'D'),
                                        (5, 'E'),
                                        (6, 'AB'),
                                        (7, 'AC'),
                                        (8, 'AD'),
                                        (9, 'BC'),
                                        (10, 'BD'),
                                        (11, 'CD'),
                                        (12, 'DE');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM public.cnh_type");
        }
    }
}
