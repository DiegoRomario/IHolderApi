using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IHolder.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoInvestimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    Caracteristicas = table.Column<string>(type: "VARCHAR(240)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInvestimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(240)", nullable: true),
                    Genero = table.Column<byte>(type: "TINYINT", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.UniqueConstraint("AK_Usuario_Email", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    Caracteristicas = table.Column<string>(type: "VARCHAR(240)", nullable: true),
                    TipoInvestimentoId = table.Column<Guid>(nullable: false),
                    Risco = table.Column<byte>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_TipoInvestimento_TipoInvestimentoId",
                        column: x => x.TipoInvestimentoId,
                        principalTable: "TipoInvestimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DistribuicaoPorTipoInvestimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PercentualObjetivo = table.Column<decimal>(nullable: true),
                    PercentualAtual = table.Column<decimal>(nullable: true),
                    PercentualDiferenca = table.Column<decimal>(nullable: true),
                    ValorAtual = table.Column<decimal>(nullable: true),
                    ValorDiferenca = table.Column<decimal>(nullable: true),
                    TipoInvestimentoId = table.Column<Guid>(nullable: false),
                    Orientacao = table.Column<byte>(type: "TINYINT", nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistribuicaoPorTipoInvestimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistribuicaoPorTipoInvestimento_TipoInvestimento_TipoInvestimentoId",
                        column: x => x.TipoInvestimentoId,
                        principalTable: "TipoInvestimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DistribuicaoPorTipoInvestimento_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ativo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    Caracteristicas = table.Column<string>(type: "VARCHAR(240)", nullable: true),
                    Ticker = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Cotacao = table.Column<decimal>(type: "DECIMAL(12,2)", nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Situacao = table.Column<byte>(type: "TINYINT", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ativo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ativo_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ativo_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DistribuicaoPorProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PercentualObjetivo = table.Column<decimal>(nullable: true),
                    PercentualAtual = table.Column<decimal>(nullable: true),
                    PercentualDiferenca = table.Column<decimal>(nullable: true),
                    ValorAtual = table.Column<decimal>(nullable: true),
                    ValorDiferenca = table.Column<decimal>(nullable: true),
                    ProdutoId = table.Column<Guid>(nullable: false),
                    Orientacao = table.Column<byte>(type: "TINYINT", nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistribuicaoPorProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistribuicaoPorProduto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DistribuicaoPorProduto_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aporte",
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

            migrationBuilder.CreateTable(
                name: "DistribuicaoPorAtivo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PercentualObjetivo = table.Column<decimal>(type: "DECIMAL(12,2)", nullable: true),
                    PercentualAtual = table.Column<decimal>(type: "DECIMAL(12,2)", nullable: true),
                    PercentualDiferenca = table.Column<decimal>(type: "DECIMAL(12,2)", nullable: true),
                    ValorAtual = table.Column<decimal>(type: "DECIMAL(12,2)", nullable: true),
                    ValorDiferenca = table.Column<decimal>(type: "DECIMAL(12,2)", nullable: true),
                    AtivoId = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Orientacao = table.Column<byte>(type: "TINYINT", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistribuicaoPorAtivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistribuicaoPorAtivo_Ativo_AtivoId",
                        column: x => x.AtivoId,
                        principalTable: "Ativo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DistribuicaoPorAtivo_Usuario_UsuarioId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Ativo_ProdutoId",
                table: "Ativo",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ativo_UsuarioId",
                table: "Ativo",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DistribuicaoPorAtivo_AtivoId",
                table: "DistribuicaoPorAtivo",
                column: "AtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_DistribuicaoPorAtivo_UsuarioId",
                table: "DistribuicaoPorAtivo",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DistribuicaoPorProduto_ProdutoId",
                table: "DistribuicaoPorProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_DistribuicaoPorProduto_UsuarioId",
                table: "DistribuicaoPorProduto",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DistribuicaoPorTipoInvestimento_TipoInvestimentoId",
                table: "DistribuicaoPorTipoInvestimento",
                column: "TipoInvestimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_DistribuicaoPorTipoInvestimento_UsuarioId",
                table: "DistribuicaoPorTipoInvestimento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_TipoInvestimentoId",
                table: "Produto",
                column: "TipoInvestimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aporte");

            migrationBuilder.DropTable(
                name: "DistribuicaoPorAtivo");

            migrationBuilder.DropTable(
                name: "DistribuicaoPorProduto");

            migrationBuilder.DropTable(
                name: "DistribuicaoPorTipoInvestimento");

            migrationBuilder.DropTable(
                name: "Ativo");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoInvestimento");
        }
    }
}
