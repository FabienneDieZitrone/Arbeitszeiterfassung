/*
Titel: SyncConfiguration
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Sync/SyncConfiguration.cs
Beschreibung: Konfigurationsoptionen fuer die Synchronisation.
*/
using Arbeitszeiterfassung.DAL.Interfaces;

namespace Arbeitszeiterfassung.DAL.Sync;

/// <summary>
/// Einstellungen fuer die Synchronisation.
/// </summary>
public class SyncConfiguration
{
    public Dictionary<Type, ConflictStrategy> EntityStrategies { get; set; } = new();
    public int MaxRetryCount { get; set; } = 3;
    public int RetryDelaySeconds { get; set; } = 5;
    public int BatchSize { get; set; } = 100;
    public ConflictStrategy DefaultStrategy { get; set; } = ConflictStrategy.ServerWins;
}
