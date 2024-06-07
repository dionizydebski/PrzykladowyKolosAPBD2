using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrzykładowyKolos2.Migrations
{
    /// <inheritdoc />
    public partial class DodanoWytwornieIAlbum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MuzykUtwor_Utwory_UtworyIdUtwor",
                table: "MuzykUtwor");

            migrationBuilder.RenameColumn(
                name: "UtworyIdUtwor",
                table: "MuzykUtwor",
                newName: "UtworIdUtwor");

            migrationBuilder.RenameIndex(
                name: "IX_MuzykUtwor_UtworyIdUtwor",
                table: "MuzykUtwor",
                newName: "IX_MuzykUtwor_UtworIdUtwor");

            migrationBuilder.AddColumn<int>(
                name: "IdAlbum",
                table: "Utwory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Wytwornie",
                columns: table => new
                {
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wytwornie", x => x.IdWytwornia);
                });

            migrationBuilder.CreateTable(
                name: "Albumy",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaAlbumu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DataWydania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albumy", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Albumy_Wytwornie_IdWytwornia",
                        column: x => x.IdWytwornia,
                        principalTable: "Wytwornie",
                        principalColumn: "IdWytwornia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utwory_IdAlbum",
                table: "Utwory",
                column: "IdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_Albumy_IdWytwornia",
                table: "Albumy",
                column: "IdWytwornia");

            migrationBuilder.AddForeignKey(
                name: "FK_MuzykUtwor_Utwory_UtworIdUtwor",
                table: "MuzykUtwor",
                column: "UtworIdUtwor",
                principalTable: "Utwory",
                principalColumn: "IdUtwor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Utwory_Albumy_IdAlbum",
                table: "Utwory",
                column: "IdAlbum",
                principalTable: "Albumy",
                principalColumn: "IdAlbum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MuzykUtwor_Utwory_UtworIdUtwor",
                table: "MuzykUtwor");

            migrationBuilder.DropForeignKey(
                name: "FK_Utwory_Albumy_IdAlbum",
                table: "Utwory");

            migrationBuilder.DropTable(
                name: "Albumy");

            migrationBuilder.DropTable(
                name: "Wytwornie");

            migrationBuilder.DropIndex(
                name: "IX_Utwory_IdAlbum",
                table: "Utwory");

            migrationBuilder.DropColumn(
                name: "IdAlbum",
                table: "Utwory");

            migrationBuilder.RenameColumn(
                name: "UtworIdUtwor",
                table: "MuzykUtwor",
                newName: "UtworyIdUtwor");

            migrationBuilder.RenameIndex(
                name: "IX_MuzykUtwor_UtworIdUtwor",
                table: "MuzykUtwor",
                newName: "IX_MuzykUtwor_UtworyIdUtwor");

            migrationBuilder.AddForeignKey(
                name: "FK_MuzykUtwor_Utwory_UtworyIdUtwor",
                table: "MuzykUtwor",
                column: "UtworyIdUtwor",
                principalTable: "Utwory",
                principalColumn: "IdUtwor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
