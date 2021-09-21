using Microsoft.EntityFrameworkCore.Migrations;

namespace NerdStore.Catalogo.Data.Migrations
{
    public partial class Alteração_coluan_Valor_Produto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Produto",
                type: "DECIMAL(19,5)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Produto",
                type: "BIT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Produto",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(19,5)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Produto",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BIT");
        }
    }
}
