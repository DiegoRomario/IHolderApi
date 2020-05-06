using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IHolder.Data.Migrations
{
    public partial class RefactoringUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Usuario_CPF",
                table: "Usuario");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Usuario_Celular",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Data_nascimento",
                table: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Usuario",
                type: "VARCHAR(25)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Usuario",
                type: "VARCHAR(25)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_nascimento",
                table: "Usuario",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Usuario_CPF",
                table: "Usuario",
                column: "CPF");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Usuario_Celular",
                table: "Usuario",
                column: "Celular");
        }
    }
}
