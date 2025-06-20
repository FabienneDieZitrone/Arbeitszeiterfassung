/*
Titel: ApplicationDbContext.cs
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Context/ApplicationDbContext.cs
Beschreibung: Haupt-DbContext für MySQL/MariaDB mit Fluent API Konfiguration.
*/

using Microsoft.EntityFrameworkCore;
using Arbeitszeiterfassung.Common.Enums;
using Arbeitszeiterfassung.DAL.Entities;

namespace Arbeitszeiterfassung.DAL.Context;

/// <summary>
/// Datenbankkontext für die Produktionsdatenbank.
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Benutzer> Benutzer => Set<Benutzer>();
    public DbSet<Rolle> Rollen => Set<Rolle>();
    public DbSet<Stammdaten> Stammdaten => Set<Stammdaten>();
    public DbSet<Standort> Standorte => Set<Standort>();
    public DbSet<BenutzerStandort> BenutzerStandorte => Set<BenutzerStandort>();
    public DbSet<Arbeitszeit> Arbeitszeiten => Set<Arbeitszeit>();
    public DbSet<Aenderungsprotokoll> Aenderungsprotokolle => Set<Aenderungsprotokoll>();
    public DbSet<Systemeinstellung> Systemeinstellungen => Set<Systemeinstellung>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            const string connectionString = "server=wp10454681.Server-he.de;database=db10454681-aze;uid=db10454681-aze;pwd=Start.321;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Rolle>().HasData(
            new Rolle { RolleId = 1, Bezeichnung = "Mitarbeiter", Berechtigungsstufe = Berechtigungsstufe.Mitarbeiter },
            new Rolle { RolleId = 2, Bezeichnung = "Honorarkraft", Berechtigungsstufe = Berechtigungsstufe.Honorarkraft },
            new Rolle { RolleId = 3, Bezeichnung = "Standortleiter", Berechtigungsstufe = Berechtigungsstufe.Standortleiter },
            new Rolle { RolleId = 4, Bezeichnung = "Bereichsleiter", Berechtigungsstufe = Berechtigungsstufe.Bereichsleiter },
            new Rolle { RolleId = 5, Bezeichnung = "Admin", Berechtigungsstufe = Berechtigungsstufe.Admin }
        );

        modelBuilder.Entity<BenutzerStandort>().HasKey(bs => new { bs.BenutzerId, bs.StandortId });
        modelBuilder.Entity<Arbeitszeit>().HasIndex(a => new { a.BenutzerId, a.Datum }).HasDatabaseName("idx_benutzer_datum");
    }
}
