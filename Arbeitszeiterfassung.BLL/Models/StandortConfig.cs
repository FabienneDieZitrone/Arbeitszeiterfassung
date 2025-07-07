/*
Titel: StandortConfig
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Models/StandortConfig.cs
Beschreibung: Einstellungen fuer Standortdaten
*/

/// <summary>
/// Konfiguration zur Standortermittlung.
/// </summary>
public class StandortConfig
{
    public required string IPRangeStart { get; set; }
    public required string IPRangeEnd { get; set; }
    public bool IsHomeOffice { get; set; }
}
