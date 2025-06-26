/*
Titel: SyncRepository
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Repositories/Offline/SyncRepository.cs
Beschreibung: Repository zur Synchronisation zwischen Offline- und Online-Datenbank.
*/

using Arbeitszeiterfassung.DAL.Context;
using Arbeitszeiterfassung.DAL.Interfaces;

namespace Arbeitszeiterfassung.DAL.Repositories.Offline;

/// <summary>
/// Spezialisiertes Repository zur Synchronisation.
/// </summary>
public class SyncRepository<T> : OfflineRepository<T> where T : class
{
    public SyncRepository(OfflineDbContext ctx, ISyncService syncService)
        : base(ctx, syncService)
    {
    }

    // Platzhalter fuer Sync-Logik
}
