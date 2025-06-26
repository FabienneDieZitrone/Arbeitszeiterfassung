/*
Titel: SyncQueueRepository
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Repositories/Offline/SyncQueueRepository.cs
Beschreibung: Repository fuer die SyncQueue.
*/
using Arbeitszeiterfassung.DAL.Context;
using Arbeitszeiterfassung.DAL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.DAL.Repositories.Offline;

/// <summary>
/// Repository zur Verwaltung der SyncQueue.
/// </summary>
public class SyncQueueRepository : OfflineRepository<SyncQueue>
{
    public SyncQueueRepository(OfflineDbContext ctx, ISyncService syncService)
        : base(ctx, syncService) { }
}
