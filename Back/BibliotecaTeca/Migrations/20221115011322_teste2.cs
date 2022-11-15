using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaTeca.Migrations
{
    public partial class teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Bibliotecas_BibliotecaId",
                table: "Livros");

            migrationBuilder.AlterColumn<int>(
                name: "BibliotecaId",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Bibliotecas_BibliotecaId",
                table: "Livros",
                column: "BibliotecaId",
                principalTable: "Bibliotecas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Bibliotecas_BibliotecaId",
                table: "Livros");

            migrationBuilder.AlterColumn<int>(
                name: "BibliotecaId",
                table: "Livros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Bibliotecas_BibliotecaId",
                table: "Livros",
                column: "BibliotecaId",
                principalTable: "Bibliotecas",
                principalColumn: "Id");
        }
    }
}
