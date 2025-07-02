/*
Titel: SyncSettings
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Configuration/Models/SyncSettings.cs
Beschreibung: Einstellungen zur Offline-Synchronisation.
*/

namespace Arbeitszeiterfassung.Common.Configuration.Models;

/// <summary>
/// Konfiguration fuer die Synchronisationsroutine.
/// </summary>
public class SyncSettings
{
    public int IntervalSeconds { get; set; } = 30;
    public int BatchSize { get; set; } = 100;
    public bool AutoSyncEnabled { get; set; } = true;
    public int ConflictResolutionMode { get; set; } = 1;
}
