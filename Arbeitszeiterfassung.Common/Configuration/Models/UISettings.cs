/*
Titel: UISettings
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Configuration/Models/UISettings.cs
Beschreibung: Benutzerschnittstellenbezogene Einstellungen.
*/

namespace Arbeitszeiterfassung.Common.Configuration.Models;

/// <summary>
/// Einstellungen fuer die Benutzeroberflaeche.
/// </summary>
public class UISettings
{
    public string Theme { get; set; } = "Standard";
    public int SessionTimeoutMinutes { get; set; } = 30;
    public bool ShowToolTips { get; set; } = true;
    public string DateFormat { get; set; } = "dd.MM.yyyy";
    public string TimeFormat { get; set; } = "HH:mm:ss";
}
