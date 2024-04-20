using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaACME.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pacientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    data_de_nascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    cpf = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    sexo = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false),
                    endereco = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pacientes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pacientes_cpf",
                table: "pacientes",
                column: "cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pacientes");
        }
    }
}
