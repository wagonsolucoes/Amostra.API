using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amostra.API.Migrations.Amostra
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CpfCnpj = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(350)", unicode: false, maxLength: 350, nullable: false),
                    Numero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Localidade = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Uf = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Email = table.Column<string>(type: "varchar(350)", unicode: false, maxLength: 350, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Nascimento = table.Column<DateTime>(type: "date", nullable: true),
                    Idade = table.Column<int>(type: "int", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Deleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cliente__0BCA032B56169987", x => x.CpfCnpj);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DhCompra = table.Column<DateTime>(type: "datetime", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(350)", unicode: false, maxLength: 350, nullable: false),
                    Prefacio = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Autor = table.Column<string>(type: "varchar(350)", unicode: false, maxLength: 350, nullable: false),
                    Editora = table.Column<string>(type: "varchar(350)", unicode: false, maxLength: 350, nullable: false),
                    DhExtravio = table.Column<DateTime>(type: "datetime", nullable: true),
                    Extraviado = table.Column<bool>(type: "bit", nullable: true),
                    Emprestado = table.Column<bool>(type: "bit", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Livro__3214EC074E7EA799", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emprestado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCliente = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: false),
                    IdLivro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dh = table.Column<DateTime>(type: "datetime", nullable: false),
                    DhDevolucao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiasEmprestado = table.Column<int>(type: "int", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empresta__3214EC0764AA5852", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestado_Cliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "CpfCnpj");
                    table.ForeignKey(
                        name: "FK_Emprestado_Livro",
                        column: x => x.IdLivro,
                        principalTable: "Livro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestado_IdCliente",
                table: "Emprestado",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestado_IdLivro",
                table: "Emprestado",
                column: "IdLivro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestado");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
