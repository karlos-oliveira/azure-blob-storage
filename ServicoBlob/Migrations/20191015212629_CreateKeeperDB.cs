using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicoBlob.Migrations
{
    public partial class CreateKeeperDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InformacaoArquivo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Tamanho = table.Column<double>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    IdUsuario = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacaoArquivo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformacaoArquivo");
        }
    }
}
