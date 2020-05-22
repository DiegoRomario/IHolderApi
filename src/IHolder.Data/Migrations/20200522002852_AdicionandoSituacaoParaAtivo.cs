using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IHolder.Data.Migrations
{
    public partial class AdicionandoSituacaoParaAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SituacaoPorAtivo");

            migrationBuilder.AddColumn<byte>(
                name: "Situacao",
                table: "Ativo",
                type: "TINYINT",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "Ativo");

            migrationBuilder.CreateTable(
                name: "SituacaoPorAtivo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(240)", nullable: true),
                    Situacao = table.Column<byte>(type: "TINYINT", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoPorAtivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SituacaoPorAtivo_Ativo_AtivoId",
                        column: x => x.AtivoId,
                        principalTable: "Ativo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SituacaoPorAtivo_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SituacaoPorAtivo_AtivoId",
                table: "SituacaoPorAtivo",
                column: "AtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_SituacaoPorAtivo_UsuarioId",
                table: "SituacaoPorAtivo",
                column: "UsuarioId");
        }
    }
}
