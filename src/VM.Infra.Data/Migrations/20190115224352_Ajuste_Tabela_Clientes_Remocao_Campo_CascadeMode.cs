using Microsoft.EntityFrameworkCore.Migrations;

namespace VM.Infra.Data.Migrations
{
    public partial class Ajuste_Tabela_Clientes_Remocao_Campo_CascadeMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco_CascadeMode",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Cpf_CascadeMode",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Endereco_Cep_CascadeMode",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Email_CascadeMode",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Idade_CascadeMode",
                table: "Clientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Endereco_CascadeMode",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cpf_CascadeMode",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Endereco_Cep_CascadeMode",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Email_CascadeMode",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Idade_CascadeMode",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);
        }
    }
}
