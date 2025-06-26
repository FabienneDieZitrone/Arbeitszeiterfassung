/*
Titel: OfflineRepository
Version: 1.1
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Repositories/Offline/OfflineRepository.cs
Beschreibung: Generisches Repository fuer den Offline-Modus.
*/

using Arbeitszeiterfassung.DAL.Context;
using Arbeitszeiterfassung.DAL.Repositories;
using Arbeitszeiterfassung.DAL.Interfaces;
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.DAL.Repositories.Offline;

/// <summary>
/// Basisklasse fuer Offline-Repositories mit SQLite.
/// </summary>
public class OfflineRepository<T> : GenericRepository<T> where T : class
{
    private readonly ISyncService syncService;

    public OfflineRepository(OfflineDbContext ctx, ISyncService syncService) : base(ctx)
    {
        this.syncService = syncService;
    }

    public override async Task<T> AddAsync(T entity)
    {
        var result = await base.AddAsync(entity);
        await syncService.QueueForSyncAsync(entity, SyncOperation.Insert);
        return result;
    }

    public override async Task UpdateAsync(T entity)
    {
        await base.UpdateAsync(entity);
        await syncService.QueueForSyncAsync(entity, SyncOperation.Update);
    }

    public override async Task DeleteAsync(T entity)
    {
        await base.DeleteAsync(entity);
        await syncService.QueueForSyncAsync(entity, SyncOperation.Delete);
    }
}
