using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NerdStore.Catalogo.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Codigo = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoriaId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Imagem = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    QuantidadeEstoque = table.Column<int>(nullable: false),
                    Altura = table.Column<int>(type: "INT", nullable: true),
                    Largura = table.Column<int>(type: "INT", nullable: true),
                    Profundidade = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
