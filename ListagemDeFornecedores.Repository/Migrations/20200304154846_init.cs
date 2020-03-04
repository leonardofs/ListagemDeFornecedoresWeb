using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListagemDeFornecedores.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    FornecedorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpresaId = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    NomeFornecedor = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpresaFornecedorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.FornecedorId);
                    table.ForeignKey(
                        name: "FK_Fornecedores_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fornecedores_Empresas_EmpresaFornecedorId",
                        column: x => x.EmpresaFornecedorId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_EmpresaId",
                table: "Fornecedores",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_EmpresaFornecedorId",
                table: "Fornecedores",
                column: "EmpresaFornecedorId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
