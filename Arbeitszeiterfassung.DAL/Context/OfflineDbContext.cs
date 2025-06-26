/*
Titel: OfflineDbContext
Version: 1.1
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Context/OfflineDbContext.cs
Beschreibung: SQLite-Kontext fuer Offline-Betrieb
*/

using Microsoft.EntityFrameworkCore;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.DAL.Context;

/// <summary>
/// Datenbankkontext fuer den Offline-Modus (SQLite).
/// </summary>
public class OfflineDbContext : ApplicationDbContext
{
    public OfflineDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<SyncQueue> SyncQueue => Set<SyncQueue>();
    public DbSet<SyncLog> SyncLogs => Set<SyncLog>();
    public DbSet<SyncMetadata> SyncMetadata => Set<SyncMetadata>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlite("Data Source=arbeitszeiterfassung.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<SyncMetadata>().HasKey(m => m.TableName);
    }
}
