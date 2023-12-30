using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aula_31_RazorPages_Filmes_8.Migrations
{
    public partial class adicionandopontos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pontos",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pontos",
                table: "Filmes");
        }
    }
}
