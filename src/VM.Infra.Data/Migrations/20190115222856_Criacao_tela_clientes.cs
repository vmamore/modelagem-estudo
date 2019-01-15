using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VM.Infra.Data.Migrations
{
    public partial class Criacao_tela_clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 150, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Endereco_CascadeMode = table.Column<int>(nullable: false),
                    Endereco_Logradouro = table.Column<string>(maxLength: 150, nullable: false),
                    Endereco_Numero = table.Column<string>(maxLength: 10, nullable: false),
                    Endereco_Cidade = table.Column<string>(maxLength: 100, nullable: false),
                    Endereco_Estado = table.Column<string>(maxLength: 2, nullable: false),
                    Endereco_Bairro = table.Column<string>(maxLength: 100, nullable: false),
                    Endereco_Complemento = table.Column<string>(maxLength: 200, nullable: true),
                    Endereco_Cep_CascadeMode = table.Column<int>(nullable: false),
                    Endereco_Cep_Numero = table.Column<string>(maxLength: 8, nullable: false),
                    Idade_CascadeMode = table.Column<int>(nullable: false),
                    Idade_DataNascimento = table.Column<DateTime>(nullable: false),
                    Email_CascadeMode = table.Column<int>(nullable: false),
                    Email_Endereco = table.Column<string>(maxLength: 300, nullable: false),
                    Cpf_CascadeMode = table.Column<int>(nullable: false),
                    Cpf_Numero = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
