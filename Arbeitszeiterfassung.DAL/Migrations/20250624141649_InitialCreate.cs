using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Arbeitszeiterfassung.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Aenderungsprotokolle",
                columns: table => new
                {
                    AenderungsprotokollId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EntityName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityId = table.Column<int>(type: "int", nullable: true),
                    Aktion = table.Column<int>(type: "int", nullable: false),
                    Grund = table.Column<int>(type: "int", nullable: false),
                    GrundText = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Genehmigt = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ErstelltAm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GeaendertAm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GeaendertVon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aenderungsprotokolle", x => x.AenderungsprotokollId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AppRessourcen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bezeichnung = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Daten = table.Column<byte[]>(type: "longblob", nullable: false),
                    LetzteAktualisierung = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ErstelltAm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GeaendertAm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GeaendertVon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRessourcen", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rollen",
                columns: table => new
                {
                    RolleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bezeichnung = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Berechtigungsstufe = table.Column<int>(type: "int", nullable: false),
                    Beschreibung = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ErstelltAm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GeaendertAm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GeaendertVon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rollen", x => x.RolleId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Standorte",
                columns: table => new
                {
                    StandortId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bezeichnung = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adresse = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IPRangeStart = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IPRangeEnd = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ErstelltAm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GeaendertAm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GeaendertVon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standorte", x => x.StandortId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Systemeinstellungen",
                columns: table => new
                {
                    SystemeinstellungId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Schluessel = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Typ = table.Column<int>(type: "int", nullable: false),
                    WertString = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WertNumber = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    WertBoolean = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    WertJson = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ErstelltAm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GeaendertAm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GeaendertVon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systemeinstellungen", x => x.SystemeinstellungId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Benutzer",
                columns: table => new
                {
                    BenutzerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Vorname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nachname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RolleId = table.Column<int>(type: "int", nullable: false),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ErstelltAm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GeaendertAm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GeaendertVon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benutzer", x => x.BenutzerId);
                    table.ForeignKey(
                        name: "FK_Benutzer_Rollen_RolleId",
                        column: x => x.RolleId,
                        principalTable: "Rollen",
                        principalColumn: "RolleId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Arbeitszeiten",
                columns: table => new
                {
                    ArbeitszeitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BenutzerId = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Stopp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Pause = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    IstOfflineErfasst = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IstSynchronisiert = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ErstelltAm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GeaendertAm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GeaendertVon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbeitszeiten", x => x.ArbeitszeitId);
                    table.ForeignKey(
                        name: "FK_Arbeitszeiten_Benutzer_BenutzerId",
                        column: x => x.BenutzerId,
                        principalTable: "Benutzer",
                        principalColumn: "BenutzerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BenutzerStandorte",
                columns: table => new
                {
                    BenutzerId = table.Column<int>(type: "int", nullable: false),
                    StandortId = table.Column<int>(type: "int", nullable: false),
                    IstHauptstandort = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ZugewiesenAm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ErstelltAm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GeaendertAm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GeaendertVon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenutzerStandorte", x => new { x.BenutzerId, x.StandortId });
                    table.ForeignKey(
                        name: "FK_BenutzerStandorte_Benutzer_BenutzerId",
                        column: x => x.BenutzerId,
                        principalTable: "Benutzer",
                        principalColumn: "BenutzerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenutzerStandorte_Standorte_StandortId",
                        column: x => x.StandortId,
                        principalTable: "Standorte",
                        principalColumn: "StandortId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stammdaten",
                columns: table => new
                {
                    StammdatenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BenutzerId = table.Column<int>(type: "int", nullable: false),
                    Wochenarbeitszeit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ArbeitstagMo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ArbeitstagDi = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ArbeitstagMi = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ArbeitstagDo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ArbeitstagFr = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HomeOfficeErlaubt = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ErstelltAm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GeaendertAm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GeaendertVon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stammdaten", x => x.StammdatenId);
                    table.ForeignKey(
                        name: "FK_Stammdaten_Benutzer_BenutzerId",
                        column: x => x.BenutzerId,
                        principalTable: "Benutzer",
                        principalColumn: "BenutzerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Rollen",
                columns: new[] { "RolleId", "Aktiv", "Berechtigungsstufe", "Beschreibung", "Bezeichnung", "ErstelltAm", "GeaendertAm", "GeaendertVon" },
                values: new object[,]
                {
                    { 1, true, 5, "Administrator", "Admin", new DateTime(2025, 6, 24, 14, 16, 48, 318, DateTimeKind.Utc).AddTicks(5888), null, null },
                    { 2, true, 1, "Standardbenutzer", "Mitarbeiter", new DateTime(2025, 6, 24, 14, 16, 48, 318, DateTimeKind.Utc).AddTicks(5900), null, null },
                    { 3, true, 3, "Teamleitung", "Manager", new DateTime(2025, 6, 24, 14, 16, 48, 318, DateTimeKind.Utc).AddTicks(5903), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arbeitszeiten_BenutzerId",
                table: "Arbeitszeiten",
                column: "BenutzerId");

            migrationBuilder.CreateIndex(
                name: "IX_Arbeitszeiten_Start",
                table: "Arbeitszeiten",
                column: "Start");

            migrationBuilder.CreateIndex(
                name: "IX_Benutzer_RolleId",
                table: "Benutzer",
                column: "RolleId");

            migrationBuilder.CreateIndex(
                name: "IX_Benutzer_Username",
                table: "Benutzer",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BenutzerStandorte_StandortId",
                table: "BenutzerStandorte",
                column: "StandortId");

            migrationBuilder.CreateIndex(
                name: "IX_Stammdaten_BenutzerId",
                table: "Stammdaten",
                column: "BenutzerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aenderungsprotokolle");

            migrationBuilder.DropTable(
                name: "AppRessourcen");

            migrationBuilder.DropTable(
                name: "Arbeitszeiten");

            migrationBuilder.DropTable(
                name: "BenutzerStandorte");

            migrationBuilder.DropTable(
                name: "Stammdaten");

            migrationBuilder.DropTable(
                name: "Systemeinstellungen");

            migrationBuilder.DropTable(
                name: "Standorte");

            migrationBuilder.DropTable(
                name: "Benutzer");

            migrationBuilder.DropTable(
                name: "Rollen");
        }
    }
}
