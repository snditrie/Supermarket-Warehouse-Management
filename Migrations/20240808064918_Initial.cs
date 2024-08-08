using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SuperMarketApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gudangs",
                columns: table => new
                {
                    GudangID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaGudang = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gudangs", x => x.GudangID);
                });

            migrationBuilder.CreateTable(
                name: "Barangs",
                columns: table => new
                {
                    BarangID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KodeBarang = table.Column<string>(type: "text", nullable: true),
                    NamaBarang = table.Column<string>(type: "text", nullable: true),
                    HargaBarang = table.Column<decimal>(type: "numeric", nullable: false),
                    JumlahBarang = table.Column<int>(type: "integer", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    GudangID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barangs", x => x.BarangID);
                    table.ForeignKey(
                        name: "FK_Barangs_Gudangs_GudangID",
                        column: x => x.GudangID,
                        principalTable: "Gudangs",
                        principalColumn: "GudangID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barangs_GudangID",
                table: "Barangs",
                column: "GudangID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barangs");

            migrationBuilder.DropTable(
                name: "Gudangs");
        }
    }
}
