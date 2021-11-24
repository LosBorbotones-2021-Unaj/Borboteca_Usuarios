using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Borboteca_Usuarios.AccesData.Migrations
{
    public partial class usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roll", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Rollid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roll_Rollid",
                        column: x => x.Rollid,
                        principalTable: "Roll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libroid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Usuariosid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favoritos_Usuarios_Usuariosid",
                        column: x => x.Usuariosid,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roll",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 1, "user" });

            migrationBuilder.InsertData(
                table: "Roll",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 2, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_Usuariosid",
                table: "Favoritos",
                column: "Usuariosid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Rollid",
                table: "Usuarios",
                column: "Rollid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roll");
        }
    }
}
