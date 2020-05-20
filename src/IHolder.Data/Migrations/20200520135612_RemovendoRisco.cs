using Microsoft.EntityFrameworkCore.Migrations;

namespace IHolder.Data.Migrations
{
    public partial class RemovendoRisco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Risco",
                table: "TipoInvestimento");

            migrationBuilder.DropColumn(
                name: "Risco",
                table: "Ativo");

            migrationBuilder.AddColumn<byte>(
                name: "Risco",
                table: "Produto",
                type: "TINYINT",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Risco",
                table: "Produto");

            migrationBuilder.AddColumn<byte>(
                name: "Risco",
                table: "TipoInvestimento",
                type: "TINYINT",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Risco",
                table: "Ativo",
                type: "TINYINT",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
