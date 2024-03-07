using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listeler",
                columns: table => new
                {
                    ListeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListeSira = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listeler", x => x.ListeId);
                });

            migrationBuilder.CreateTable(
                name: "Kartlar",
                columns: table => new
                {
                    KartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KartIcerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KartSira = table.Column<int>(type: "int", nullable: false),
                    ListeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kartlar", x => x.KartId);
                    table.ForeignKey(
                        name: "FK_Kartlar_Listeler_ListeId",
                        column: x => x.ListeId,
                        principalTable: "Listeler",
                        principalColumn: "ListeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kartlar_ListeId",
                table: "Kartlar",
                column: "ListeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kartlar");

            migrationBuilder.DropTable(
                name: "Listeler");
        }
    }
}
