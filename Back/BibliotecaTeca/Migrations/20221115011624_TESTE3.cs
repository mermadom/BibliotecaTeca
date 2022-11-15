using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaTeca.Migrations
{
    public partial class TESTE3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Bibliotecas_BibliotecaId",
                table: "Emprestimos");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimos_BibliotecaId",
                table: "Emprestimos");

            migrationBuilder.DropColumn(
                name: "BibliotecaId",
                table: "Emprestimos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BibliotecaId",
                table: "Emprestimos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_BibliotecaId",
                table: "Emprestimos",
                column: "BibliotecaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimos_Bibliotecas_BibliotecaId",
                table: "Emprestimos",
                column: "BibliotecaId",
                principalTable: "Bibliotecas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
