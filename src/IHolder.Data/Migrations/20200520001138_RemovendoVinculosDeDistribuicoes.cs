using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IHolder.Data.Migrations
{
    public partial class RemovendoVinculosDeDistribuicoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistribuicaoPorAtivo_DistribuicaoPorProduto_DistribuicaoPorProdutoId",
                table: "DistribuicaoPorAtivo");

            migrationBuilder.DropForeignKey(
                name: "FK_DistribuicaoPorProduto_DistribuicaoPorTipoInvestimento_DistribuicaoPorTipoInvestimentoId",
                table: "DistribuicaoPorProduto");

            migrationBuilder.DropIndex(
                name: "IX_DistribuicaoPorProduto_DistribuicaoPorTipoInvestimentoId",
                table: "DistribuicaoPorProduto");

            migrationBuilder.DropIndex(
                name: "IX_DistribuicaoPorAtivo_DistribuicaoPorProdutoId",
                table: "DistribuicaoPorAtivo");

            migrationBuilder.DropColumn(
                name: "DistribuicaoPorTipoInvestimentoId",
                table: "DistribuicaoPorProduto");

            migrationBuilder.DropColumn(
                name: "DistribuicaoPorProdutoId",
                table: "DistribuicaoPorAtivo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DistribuicaoPorTipoInvestimentoId",
                table: "DistribuicaoPorProduto",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DistribuicaoPorProdutoId",
                table: "DistribuicaoPorAtivo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DistribuicaoPorProduto_DistribuicaoPorTipoInvestimentoId",
                table: "DistribuicaoPorProduto",
                column: "DistribuicaoPorTipoInvestimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_DistribuicaoPorAtivo_DistribuicaoPorProdutoId",
                table: "DistribuicaoPorAtivo",
                column: "DistribuicaoPorProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DistribuicaoPorAtivo_DistribuicaoPorProduto_DistribuicaoPorProdutoId",
                table: "DistribuicaoPorAtivo",
                column: "DistribuicaoPorProdutoId",
                principalTable: "DistribuicaoPorProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DistribuicaoPorProduto_DistribuicaoPorTipoInvestimento_DistribuicaoPorTipoInvestimentoId",
                table: "DistribuicaoPorProduto",
                column: "DistribuicaoPorTipoInvestimentoId",
                principalTable: "DistribuicaoPorTipoInvestimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
