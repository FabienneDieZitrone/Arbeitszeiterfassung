/*
Titel: Berechtigungsstufe.cs
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Enums/Berechtigungsstufe.cs
Beschreibung: Aufzählung für die Berechtigungsstufen der Benutzer.
*/

namespace Arbeitszeiterfassung.Common.Enums;

/// <summary>
/// Definiert die verschiedenen Berechtigungsstufen im System.
/// </summary>
public enum Berechtigungsstufe
{
    Mitarbeiter = 1,
    Honorarkraft = 2,
    Standortleiter = 3,
    Bereichsleiter = 4,
    Admin = 5
}
