/*
Titel: SyncMetadata Model
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Models/SyncMetadata.cs
Beschreibung: Metadaten fuer Offline-Synchronisation.
*/

namespace Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Speichert Metadaten zur letzten Synchronisation.
/// </summary>
public class SyncMetadata
{
    public string TableName { get; set; } = string.Empty;
    public DateTime? LastSyncTime { get; set; }
    public long? LastSyncVersion { get; set; }
    public int PendingChanges { get; set; }
}
