/*
Titel: SyncService
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Sync/SyncService.cs
Beschreibung: Grundlegender Synchronisationsdienst.
*/
using Arbeitszeiterfassung.Common.Enums;
using Arbeitszeiterfassung.DAL.Context;
using Arbeitszeiterfassung.DAL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Arbeitszeiterfassung.DAL.Sync;

/// <summary>
/// Implementiert die grundlegende Synchronisation.
/// </summary>
public class SyncService : ISyncService
{
    private readonly OfflineDbContext offlineContext;
    private readonly INetworkMonitor networkMonitor;

    public event EventHandler<SyncEventArgs>? SyncStatusChanged;

    public SyncService(OfflineDbContext offlineContext, INetworkMonitor networkMonitor)
    {
        this.offlineContext = offlineContext;
        this.networkMonitor = networkMonitor;
    }

    public Task<bool> IsOnlineAsync() => networkMonitor.CheckConnectivityAsync();

    public Task<IEnumerable<SyncQueue>> GetPendingSyncItemsAsync() =>
        Task.FromResult<IEnumerable<SyncQueue>>(offlineContext.SyncQueue.Where(q => q.Status == SyncStatus.Neu).ToList());

    public async Task QueueForSyncAsync<T>(T entity, SyncOperation operation) where T : class
    {
        var queue = new SyncQueue
        {
            EntityType = typeof(T).Name,
            EntityId = 0,
            Operation = operation,
            SerializedData = string.Empty
        };
        offlineContext.SyncQueue.Add(queue);
        await offlineContext.SaveChangesAsync();
    }

    public Task<SyncResult> SyncAllAsync()
    {
        SyncStatusChanged?.Invoke(this, new SyncEventArgs { Status = SyncStatus.Erfolgreich });
        return Task.FromResult(new SyncResult { Success = true });
    }

    public Task<SyncResult> SyncEntityAsync<T>(T entity) where T : class
    {
        return Task.FromResult(new SyncResult { Success = true });
    }
}
