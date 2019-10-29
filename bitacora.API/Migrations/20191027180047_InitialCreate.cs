using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bitacora.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bitacora",
                schema: "dbo",
                columns: table => new
                {
                    bitacoraId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    bitacoraFecha = table.Column<DateTime>(type: "DateTime", nullable: false),
                    bitacoraHoraInicio = table.Column<DateTime>(type: "DateTime", nullable: false),
                    bitacoraHoraFinal = table.Column<DateTime>(type: "DateTime", nullable: false),
                    category_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacora", x => x.bitacoraId);
                    table.ForeignKey(
                        name: "FK_Bitacora_Categories_category_Id",
                        column: x => x.category_Id,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_category_Id",
                schema: "dbo",
                table: "Bitacora",
                column: "category_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacora",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
