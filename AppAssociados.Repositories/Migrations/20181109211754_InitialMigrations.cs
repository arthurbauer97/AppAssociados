using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAssociados.Repositories.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Parentesco",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parentesco", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Associado",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    cpf = table.Column<string>(nullable: true),
                    dataCadastro = table.Column<DateTime>(nullable: false),
                    ruaEndereco = table.Column<string>(nullable: true),
                    numeroEndereco = table.Column<int>(nullable: false),
                    cidade = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: true),
                    cep = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    estadoCivilid = table.Column<int>(nullable: true),
                    dataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associado", x => x.id);
                    table.ForeignKey(
                        name: "FK_Associado_EstadoCivil_estadoCivilid",
                        column: x => x.estadoCivilid,
                        principalTable: "EstadoCivil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dependente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    parentescoid = table.Column<int>(nullable: true),
                    associadoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependente", x => x.id);
                    table.ForeignKey(
                        name: "FK_Dependente_Associado_associadoid",
                        column: x => x.associadoid,
                        principalTable: "Associado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dependente_Parentesco_parentescoid",
                        column: x => x.parentescoid,
                        principalTable: "Parentesco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Associado_estadoCivilid",
                table: "Associado",
                column: "estadoCivilid");

            migrationBuilder.CreateIndex(
                name: "IX_Dependente_associadoid",
                table: "Dependente",
                column: "associadoid");

            migrationBuilder.CreateIndex(
                name: "IX_Dependente_parentescoid",
                table: "Dependente",
                column: "parentescoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependente");

            migrationBuilder.DropTable(
                name: "Associado");

            migrationBuilder.DropTable(
                name: "Parentesco");

            migrationBuilder.DropTable(
                name: "EstadoCivil");
        }
    }
}
