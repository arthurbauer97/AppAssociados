using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAssociados.Repositories.Migrations
{
    public partial class AddNomeDependente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "Dependente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nome",
                table: "Dependente");
        }
    }
}
