﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaTeca.Migrations
{
    public partial class AdicionandoOutrasTab1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Bibliotecas_BibliotecaId",
                table: "Emprestimos");

            migrationBuilder.AlterColumn<int>(
                name: "BibliotecaId",
                table: "Emprestimos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimos_Bibliotecas_BibliotecaId",
                table: "Emprestimos",
                column: "BibliotecaId",
                principalTable: "Bibliotecas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimos_Bibliotecas_BibliotecaId",
                table: "Emprestimos");

            migrationBuilder.AlterColumn<int>(
                name: "BibliotecaId",
                table: "Emprestimos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimos_Bibliotecas_BibliotecaId",
                table: "Emprestimos",
                column: "BibliotecaId",
                principalTable: "Bibliotecas",
                principalColumn: "Id");
        }
    }
}
