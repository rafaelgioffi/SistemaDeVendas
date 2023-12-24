using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeVendas.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteID",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ClienteID",
                table: "Produtos",
                column: "ClienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Clientes_ClienteID",
                table: "Produtos",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "ClienteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Clientes_ClienteID",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ClienteID",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ClienteID",
                table: "Produtos");
        }
    }
}
