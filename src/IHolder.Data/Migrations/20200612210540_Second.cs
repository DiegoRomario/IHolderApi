using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IHolder.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aporte");

            migrationBuilder.CreateTable(
                name: "AtivoEmCarteira",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AtivoId = table.Column<Guid>(nullable: false),
                    PrecoMedio = table.Column<decimal>(type: "DECIMAL(12,2)", nullable: false),
                    Quantidade = table.Column<decimal>(type: "DECIMAL(12,2)", nullable: false),
                    ValorAplicado = table.Column<decimal>(type: "DECIMAL(12,2)", nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    DataPrimeiroAporte = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtivoEmCarteira", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtivoEmCarteira_Ativo_AtivoId",
                        column: x => x.AtivoId,
                        principalTable: "Ativo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AtivoEmCarteira_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtivoEmCarteira_AtivoId",
                table: "AtivoEmCarteira",
                column: "AtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtivoEmCarteira_UsuarioId",
                table: "AtivoEmCarteira",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtivoEmCarteira");

            migrationBuilder.CreateTable(
                name: "Aporte",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataPrimeiroAporte = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PrecoMedio = table.Column<decimal>(type: "DECIMAL(12,2)", nullable: false),
                    Quantidade = table.Column<decimal>(type: "DECIMAL(12,2)", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorAplicado = table.Column<decimal>(type: "DECIMAL(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aporte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aporte_Ativo_AtivoId",
                        column: x => x.AtivoId,
                        principalTable: "Ativo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aporte_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aporte_AtivoId",
                table: "Aporte",
                column: "AtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aporte_UsuarioId",
                table: "Aporte",
                column: "UsuarioId");
        }
    }
}
