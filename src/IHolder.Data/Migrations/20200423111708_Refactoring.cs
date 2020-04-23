using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IHolder.Data.Migrations
{
    public partial class Refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ativo_Usuario_Usuario_inclusao_id",
                table: "Ativo");

            migrationBuilder.DropIndex(
                name: "IX_Ativo_Usuario_inclusao_id",
                table: "Ativo");

            migrationBuilder.DropColumn(
                name: "Usuario_inclusao_id",
                table: "Ativo");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_alteracao",
                table: "Ativo",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "Usuario_id",
                table: "Ativo",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Ativo_Usuario_id",
                table: "Ativo",
                column: "Usuario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ativo_Usuario_Usuario_id",
                table: "Ativo",
                column: "Usuario_id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ativo_Usuario_Usuario_id",
                table: "Ativo");

            migrationBuilder.DropIndex(
                name: "IX_Ativo_Usuario_id",
                table: "Ativo");

            migrationBuilder.DropColumn(
                name: "Data_alteracao",
                table: "Ativo");

            migrationBuilder.DropColumn(
                name: "Usuario_id",
                table: "Ativo");

            migrationBuilder.AddColumn<Guid>(
                name: "Usuario_inclusao_id",
                table: "Ativo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Ativo_Usuario_inclusao_id",
                table: "Ativo",
                column: "Usuario_inclusao_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ativo_Usuario_Usuario_inclusao_id",
                table: "Ativo",
                column: "Usuario_inclusao_id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
