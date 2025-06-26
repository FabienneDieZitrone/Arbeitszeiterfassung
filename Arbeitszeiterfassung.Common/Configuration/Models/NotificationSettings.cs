/*
Titel: NotificationSettings
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Configuration/Models/NotificationSettings.cs
Beschreibung: Einstellungen fuer Benachrichtigungen der Anwendung.
*/

namespace Arbeitszeiterfassung.Common.Configuration.Models;

/// <summary>
/// Benachrichtigungsspezifische Einstellungen.
/// </summary>
public class NotificationSettings
{
    public bool FridayCheck { get; set; } = true;
    public decimal OvertimeThresholdHours { get; set; } = 1.0m;
    public bool ShowSyncStatus { get; set; } = true;
    public bool PlaySounds { get; set; } = false;
}
