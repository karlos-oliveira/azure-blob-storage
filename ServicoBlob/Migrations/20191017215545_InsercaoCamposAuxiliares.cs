using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicoBlob.Migrations
{
    public partial class InsercaoCamposAuxiliares : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "InformacaoArquivo",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                table: "InformacaoArquivo",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Container",
                table: "InformacaoArquivo",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "IdConta",
                table: "InformacaoArquivo",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Container",
                table: "InformacaoArquivo");

            migrationBuilder.DropColumn(
                name: "IdConta",
                table: "InformacaoArquivo");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "InformacaoArquivo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                table: "InformacaoArquivo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
