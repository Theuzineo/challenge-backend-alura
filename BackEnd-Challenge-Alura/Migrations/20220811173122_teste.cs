using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd_Challenge_Alura.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DespesasDb",
                columns: table => new
                {
                    IdDespesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoDespesa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorDespesa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataDespesa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaDespesa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesasDb", x => x.IdDespesa);
                });

            migrationBuilder.CreateTable(
                name: "ReceitasDb",
                columns: table => new
                {
                    IdReceita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoReceita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorReceita = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataReceita = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitasDb", x => x.IdReceita);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DespesasDb");

            migrationBuilder.DropTable(
                name: "ReceitasDb");
        }
    }
}
