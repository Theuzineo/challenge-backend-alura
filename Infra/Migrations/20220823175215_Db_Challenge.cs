using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class Db_Challenge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmarSenha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "tb_Despesas",
                columns: table => new
                {
                    DespesaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoDespesa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorDespesa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataDespesa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaDespesa = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Despesas", x => x.DespesaId);
                    table.ForeignKey(
                        name: "FK_tb_Despesas_tb_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "tb_Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Receitas",
                columns: table => new
                {
                    ReceitaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoReceita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorReceita = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataReceita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Receitas", x => x.ReceitaId);
                    table.ForeignKey(
                        name: "FK_tb_Receitas_tb_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "tb_Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Despesas_UsuarioID",
                table: "tb_Despesas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Receitas_UsuarioID",
                table: "tb_Receitas",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Despesas");

            migrationBuilder.DropTable(
                name: "tb_Receitas");

            migrationBuilder.DropTable(
                name: "tb_Usuarios");
        }
    }
}
