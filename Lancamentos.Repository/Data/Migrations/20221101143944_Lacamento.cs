using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lancamentos.Repository.Data.Migrations
{
    public partial class Lacamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaixaDiarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ColaboradorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaixaDiarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaixaDiarios_AspNetUsers_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoPagamento = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instante = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CaixaDiarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamentos_CaixaDiarios_CaixaDiarioId",
                        column: x => x.CaixaDiarioId,
                        principalTable: "CaixaDiarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaixaDiarios_ColaboradorId",
                table: "CaixaDiarios",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_CaixaDiarioId",
                table: "Lancamentos",
                column: "CaixaDiarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "CaixaDiarios");
        }
    }
}
