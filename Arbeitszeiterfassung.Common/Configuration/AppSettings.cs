/*
Titel: AppSettings
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Configuration/AppSettings.cs
Beschreibung: Stellt die Konfigurationseinstellungen der Anwendung typisiert dar.
*/

using Arbeitszeiterfassung.Common.Configuration.Models;

namespace Arbeitszeiterfassung.Common.Configuration;

/// <summary>
/// Stark typisierte Konfigurationseinstellungen.
/// </summary>
public class AppSettings
{
    public DatabaseSettings Database { get; set; } = new();
    public SyncSettings Synchronisation { get; set; } = new();
    public UISettings UserInterface { get; set; } = new();
    public SecuritySettings Security { get; set; } = new();
    public NotificationSettings Notifications { get; set; } = new();
}
