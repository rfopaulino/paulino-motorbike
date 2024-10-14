using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paulino.Motorbike.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed_DocumentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    INSERT INTO public.document_type(id, name) VALUES
                                        (1, 'CNH');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM public.document_type");
        }
    }
}
