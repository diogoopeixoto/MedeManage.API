using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediManage.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoMedico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Medicos");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Medicos",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Medicos");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Pacientes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Medicos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
