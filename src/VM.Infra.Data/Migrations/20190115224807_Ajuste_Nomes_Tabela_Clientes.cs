using Microsoft.EntityFrameworkCore.Migrations;

namespace VM.Infra.Data.Migrations
{
    public partial class Ajuste_Nomes_Tabela_Clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Idade_DataNascimento",
                table: "Clientes",
                newName: "DataNascimento");

            migrationBuilder.RenameColumn(
                name: "Email_Endereco",
                table: "Clientes",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Endereco_Cep_Numero",
                table: "Clientes",
                newName: "Cep");

            migrationBuilder.RenameColumn(
                name: "Cpf_Numero",
                table: "Clientes",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "Endereco_Numero",
                table: "Clientes",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "Endereco_Logradouro",
                table: "Clientes",
                newName: "Logradouro");

            migrationBuilder.RenameColumn(
                name: "Endereco_Estado",
                table: "Clientes",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "Endereco_Complemento",
                table: "Clientes",
                newName: "Complemento");

            migrationBuilder.RenameColumn(
                name: "Endereco_Cidade",
                table: "Clientes",
                newName: "Cidade");

            migrationBuilder.RenameColumn(
                name: "Endereco_Bairro",
                table: "Clientes",
                newName: "Bairro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Clientes",
                newName: "Idade_DataNascimento");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Clientes",
                newName: "Email_Endereco");

            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "Clientes",
                newName: "Endereco_Cep_Numero");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Clientes",
                newName: "Cpf_Numero");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Clientes",
                newName: "Endereco_Numero");

            migrationBuilder.RenameColumn(
                name: "Logradouro",
                table: "Clientes",
                newName: "Endereco_Logradouro");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Clientes",
                newName: "Endereco_Estado");

            migrationBuilder.RenameColumn(
                name: "Complemento",
                table: "Clientes",
                newName: "Endereco_Complemento");

            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "Clientes",
                newName: "Endereco_Cidade");

            migrationBuilder.RenameColumn(
                name: "Bairro",
                table: "Clientes",
                newName: "Endereco_Bairro");
        }
    }
}
