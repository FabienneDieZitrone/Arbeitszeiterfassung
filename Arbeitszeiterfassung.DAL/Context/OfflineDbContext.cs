/*
Titel: OfflineDbContext
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Context/OfflineDbContext.cs
Beschreibung: SQLite-Kontext fuer Offline-Betrieb
*/

using Microsoft.EntityFrameworkCore;

namespace Arbeitszeiterfassung.DAL.Context;

/// <summary>
/// Datenbankkontext fuer den Offline-Modus (SQLite).
/// </summary>
public class OfflineDbContext : ApplicationDbContext
{
    public OfflineDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlite("Data Source=arbeitszeiterfassung.db");
        }
    }
}
