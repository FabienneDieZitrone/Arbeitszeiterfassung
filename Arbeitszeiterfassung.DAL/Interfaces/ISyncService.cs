/*
Titel: ISyncService Interface
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Interfaces/ISyncService.cs
Beschreibung: Service-Interface fuer Offline-Synchronisation.
*/
using Arbeitszeiterfassung.Common.Enums;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.DAL.Interfaces;

/// <summary>
/// Service zur Synchronisation zwischen Offline- und Online-Datenbank.
/// </summary>
public interface ISyncService
{
    Task<bool> IsOnlineAsync();
    Task<SyncResult> SyncAllAsync();
    Task<SyncResult> SyncEntityAsync<T>(T entity) where T : class;
    Task QueueForSyncAsync<T>(T entity, SyncOperation operation) where T : class;
    Task<IEnumerable<SyncQueue>> GetPendingSyncItemsAsync();
    event EventHandler<SyncEventArgs>? SyncStatusChanged;
}

/// <summary>
/// Ergebnis eines Synchronisationsvorgangs.
/// </summary>
public class SyncResult
{
    public bool Success { get; init; }
    public string? Message { get; init; }
}

/// <summary>
/// Event-Argumente fuer Sync-Status.
/// </summary>
public class SyncEventArgs : EventArgs
{
    public SyncStatus Status { get; init; }
    public int ProcessedItems { get; init; }
}
