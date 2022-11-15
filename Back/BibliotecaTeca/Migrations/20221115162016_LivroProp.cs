using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaTeca.Migrations
{
    public partial class LivroProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Editora",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumPag",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Editora",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "NumPag",
                table: "Livros");
        }
    }
}
