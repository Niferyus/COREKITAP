using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COREKİTAP.Data.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "türs",
                columns: table => new
                {
                    TürID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tür1 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_türs", x => x.TürID);
                });

            migrationBuilder.CreateTable(
                name: "kitaps",
                columns: table => new
                {
                    KitapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResimURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yazar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yayınevi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YayınlanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Konu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TürID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitaps", x => x.KitapID);
                    table.ForeignKey(
                        name: "FK_kitaps_türs_TürID",
                        column: x => x.TürID,
                        principalTable: "türs",
                        principalColumn: "TürID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "okumaGecmisis",
                columns: table => new
                {
                    OkumaGecmisiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapID = table.Column<int>(type: "int", nullable: true),
                    KullanıcıID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_okumaGecmisis", x => x.OkumaGecmisiID);
                    table.ForeignKey(
                        name: "FK_okumaGecmisis_AspNetUsers_KullanıcıID",
                        column: x => x.KullanıcıID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_okumaGecmisis_kitaps_KitapID",
                        column: x => x.KitapID,
                        principalTable: "kitaps",
                        principalColumn: "KitapID");
                });

            migrationBuilder.CreateTable(
                name: "öneris",
                columns: table => new
                {
                    ÖneriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapID = table.Column<int>(type: "int", nullable: true),
                    KullanıcıID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_öneris", x => x.ÖneriID);
                    table.ForeignKey(
                        name: "FK_öneris_AspNetUsers_KullanıcıID",
                        column: x => x.KullanıcıID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_öneris_kitaps_KitapID",
                        column: x => x.KitapID,
                        principalTable: "kitaps",
                        principalColumn: "KitapID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_kitaps_TürID",
                table: "kitaps",
                column: "TürID");

            migrationBuilder.CreateIndex(
                name: "IX_okumaGecmisis_KitapID",
                table: "okumaGecmisis",
                column: "KitapID");

            migrationBuilder.CreateIndex(
                name: "IX_okumaGecmisis_KullanıcıID",
                table: "okumaGecmisis",
                column: "KullanıcıID");

            migrationBuilder.CreateIndex(
                name: "IX_öneris_KitapID",
                table: "öneris",
                column: "KitapID");

            migrationBuilder.CreateIndex(
                name: "IX_öneris_KullanıcıID",
                table: "öneris",
                column: "KullanıcıID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "okumaGecmisis");

            migrationBuilder.DropTable(
                name: "öneris");

            migrationBuilder.DropTable(
                name: "kitaps");

            migrationBuilder.DropTable(
                name: "türs");
        }
    }
}
