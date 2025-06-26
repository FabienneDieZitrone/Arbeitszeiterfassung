/*
Titel: SyncQueue Model
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Models/SyncQueue.cs
Beschreibung: Tabelle für zu synchronisierende Entitäten.
*/
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Eintrag für die Synchronisations-Queue.
/// </summary>
public class SyncQueue
{
    public int SyncQueueId { get; set; }
    public string EntityType { get; set; } = string.Empty;
    public int EntityId { get; set; }
    public SyncOperation Operation { get; set; }
    public string SerializedData { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int RetryCount { get; set; }
    public string? LastError { get; set; }
    public SyncStatus Status { get; set; } = SyncStatus.Neu;
}
