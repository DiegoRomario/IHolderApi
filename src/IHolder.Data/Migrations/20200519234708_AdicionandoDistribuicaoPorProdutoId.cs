using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IHolder.Data.Migrations
{
    public partial class AdicionandoDistribuicaoPorProdutoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DistribuicaoPorProdutoId",
                table: "DistribuicaoPorAtivo",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistribuicaoPorAtivo_DistribuicaoPorProduto_DistribuicaoPorProdutoId",
                table: "DistribuicaoPorAtivo");

            migrationBuilder.DropIndex(
                name: "IX_DistribuicaoPorAtivo_DistribuicaoPorProdutoId",
                table: "DistribuicaoPorAtivo");

            migrationBuilder.DropColumn(
                name: "DistribuicaoPorProdutoId",
                table: "DistribuicaoPorAtivo");
        }
    }
}
