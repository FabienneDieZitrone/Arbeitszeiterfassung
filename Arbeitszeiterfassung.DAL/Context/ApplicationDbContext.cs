using Microsoft.EntityFrameworkCore;
using Arbeitszeiterfassung.DAL.Entities;

namespace Arbeitszeiterfassung.DAL.Context
{
    /// <summary>
    /// Datenbankkontext für MySQL/MariaDB.
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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("design-db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BenutzerStandort>()
                .HasKey(bs => new { bs.BenutzerId, bs.StandortId });

            modelBuilder.Entity<Rolle>().HasData(
                new Rolle { RolleId = 1, Bezeichnung = "Administrator", Berechtigungsstufe = Common.Enums.Berechtigungsstufe.Stufe1 },
                new Rolle { RolleId = 2, Bezeichnung = "Bereichsleiter", Berechtigungsstufe = Common.Enums.Berechtigungsstufe.Stufe2 },
                new Rolle { RolleId = 3, Bezeichnung = "Standortleiter", Berechtigungsstufe = Common.Enums.Berechtigungsstufe.Stufe3 },
                new Rolle { RolleId = 4, Bezeichnung = "Mitarbeiter", Berechtigungsstufe = Common.Enums.Berechtigungsstufe.Stufe4 },
                new Rolle { RolleId = 5, Bezeichnung = "Honorarkraft", Berechtigungsstufe = Common.Enums.Berechtigungsstufe.Stufe5 }
            );

            modelBuilder.Entity<Arbeitszeit>()
                .HasIndex(a => new { a.BenutzerId, a.Start });
        }
    }
}
