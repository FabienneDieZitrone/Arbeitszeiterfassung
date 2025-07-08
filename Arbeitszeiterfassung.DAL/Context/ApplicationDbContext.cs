/*
Titel: ApplicationDbContext
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Context/ApplicationDbContext.cs
Beschreibung: DbContext fuer MySQL/MariaDB
*/

using Microsoft.EntityFrameworkCore;
using Arbeitszeiterfassung.Common.Enums;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.DAL.Context;

/// <summary>
/// Hauptdatenbankkontext fuer MySQL/MariaDB.
/// </summary>
public class ApplicationDbContext : DbContext
{
    public DbSet<Benutzer> Benutzer => Set<Benutzer>();
    public DbSet<Rolle> Rollen => Set<Rolle>();
    public DbSet<Stammdaten> Stammdaten => Set<Stammdaten>();
    public DbSet<Standort> Standorte => Set<Standort>();
    public DbSet<BenutzerStandort> BenutzerStandorte => Set<BenutzerStandort>();
    public DbSet<Arbeitszeit> Arbeitszeiten => Set<Arbeitszeit>();
    public DbSet<Aenderungsprotokoll> Aenderungsprotokolle => Set<Aenderungsprotokoll>();
    public DbSet<Systemeinstellung> Systemeinstellungen => Set<Systemeinstellung>();
    public DbSet<AppRessource> AppRessourcen => Set<AppRessource>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySql(
                "server=localhost;database=aze;user=root;password=root",
                new MySqlServerVersion(new Version(8, 0, 36)));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Benutzer>(entity =>
        {
            entity.HasIndex(e => e.Username).IsUnique();
            entity.HasOne(e => e.Rolle)
                  .WithMany(r => r.Benutzer)
                  .HasForeignKey(e => e.RolleId);
            entity.HasQueryFilter(e => e.Aktiv);
        });

        modelBuilder.Entity<Stammdaten>(entity =>
        {
            entity.HasOne(d => d.Benutzer)
                  .WithOne(b => b.Stammdaten)
                  .HasForeignKey<Stammdaten>(d => d.BenutzerId);
        });

        modelBuilder.Entity<BenutzerStandort>(entity =>
        {
            entity.HasKey(e => new { e.BenutzerId, e.StandortId });
            entity.HasOne(e => e.Benutzer)
                  .WithMany(b => b.BenutzerStandorte)
                  .HasForeignKey(e => e.BenutzerId);
            entity.HasOne(e => e.Standort)
                  .WithMany(s => s.BenutzerStandorte)
                  .HasForeignKey(e => e.StandortId);
        });

        modelBuilder.Entity<Arbeitszeit>(entity =>
        {
            entity.HasIndex(a => a.Start);
            entity.HasOne(a => a.Benutzer)
                  .WithMany(b => b.Arbeitszeiten)
                  .HasForeignKey(a => a.BenutzerId);
        });

        modelBuilder.Entity<Rolle>().HasData(
            new Rolle { RolleId = 1, Bezeichnung = "Admin", Berechtigungsstufe = Berechtigungsstufe.Admin, Beschreibung = "Administrator" },
            new Rolle { RolleId = 2, Bezeichnung = "Mitarbeiter", Berechtigungsstufe = Berechtigungsstufe.Mitarbeiter, Beschreibung = "Standardbenutzer" },
            new Rolle { RolleId = 3, Bezeichnung = "Honorarkraft", Berechtigungsstufe = Berechtigungsstufe.Honorarkraft, Beschreibung = "Externe Kraft" },
            new Rolle { RolleId = 4, Bezeichnung = "Standortleiter", Berechtigungsstufe = Berechtigungsstufe.Standortleiter, Beschreibung = "Leitung eines Standorts" },
            new Rolle { RolleId = 5, Bezeichnung = "Bereichsleiter", Berechtigungsstufe = Berechtigungsstufe.Bereichsleiter, Beschreibung = "Leitung eines Bereichs" }
        );
    }
}
