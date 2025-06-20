/*
Titel: OfflineDbContext.cs
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Context/OfflineDbContext.cs
Beschreibung: DbContext für die lokale SQLite-Datenbank im Offline-Betrieb.
*/

using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Arbeitszeiterfassung.DAL.Entities;

namespace Arbeitszeiterfassung.DAL.Context;

/// <summary>
/// Datenbankkontext für den Offline-Modus.
/// </summary>
public class OfflineDbContext : ApplicationDbContext
{
    public OfflineDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = Path.Combine(folder, "Arbeitszeiterfassung", "offline.db");
            Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
