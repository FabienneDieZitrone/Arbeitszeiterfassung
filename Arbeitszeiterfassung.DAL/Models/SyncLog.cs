/*
Titel: SyncLog Model
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Models/SyncLog.cs
Beschreibung: Historie der Synchronisationsvorgaenge.
*/

namespace Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Protokolliert den Ablauf der Synchronisation.
/// </summary>
public class SyncLog
{
    public int SyncLogId { get; set; }
    public int SyncQueueId { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public string? ServerResponse { get; set; }
}
