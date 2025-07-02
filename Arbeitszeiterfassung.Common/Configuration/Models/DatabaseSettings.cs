/*
Titel: DatabaseSettings
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Configuration/Models/DatabaseSettings.cs
Beschreibung: Datenbankbezogene Einstellungen der Anwendung.
*/

namespace Arbeitszeiterfassung.Common.Configuration.Models;

/// <summary>
/// Einstellungen fuer Datenbankverbindungen und Timeout-Werte.
/// </summary>
public class DatabaseSettings
{
    public string MainConnectionString { get; set; } = string.Empty;
    public string OfflineConnectionString { get; set; } = string.Empty;
    public int CommandTimeout { get; set; } = 30;
    public bool EnableLogging { get; set; } = false;
    public int MaxRetryCount { get; set; } = 3;
}
