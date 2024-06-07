using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrzykładowyKolos2.Migrations
{
    /// <inheritdoc />
    public partial class pls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muzycy",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Pseudonim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muzycy", x => x.IdMuzyk);
                });

            migrationBuilder.CreateTable(
                name: "Utwory",
                columns: table => new
                {
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaUtworu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CzasTrwania = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utwory", x => x.IdUtwor);
                });

            migrationBuilder.CreateTable(
                name: "MuzykUtwor",
                columns: table => new
                {
                    MuzycyIdMuzyk = table.Column<int>(type: "int", nullable: false),
                    UtworyIdUtwor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuzykUtwor", x => new { x.MuzycyIdMuzyk, x.UtworyIdUtwor });
                    table.ForeignKey(
                        name: "FK_MuzykUtwor_Muzycy_MuzycyIdMuzyk",
                        column: x => x.MuzycyIdMuzyk,
                        principalTable: "Muzycy",
                        principalColumn: "IdMuzyk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuzykUtwor_Utwory_UtworyIdUtwor",
                        column: x => x.UtworyIdUtwor,
                        principalTable: "Utwory",
                        principalColumn: "IdUtwor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MuzykUtwor_UtworyIdUtwor",
                table: "MuzykUtwor",
                column: "UtworyIdUtwor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MuzykUtwor");

            migrationBuilder.DropTable(
                name: "Muzycy");

            migrationBuilder.DropTable(
                name: "Utwory");
        }
    }
}
