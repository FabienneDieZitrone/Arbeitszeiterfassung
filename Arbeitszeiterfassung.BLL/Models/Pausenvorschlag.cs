/*
Titel: Pausenvorschlag
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Models/Pausenvorschlag.cs
Beschreibung: Enthält Informationen zu vorgeschlagenen Pausen
*/

namespace Arbeitszeiterfassung.BLL.Models;

/// <summary>
/// Beschreibt einen Pausenvorschlag fuer einen Arbeitstag.
/// </summary>
public class Pausenvorschlag
{
    public TimeSpan EmpfohlenePause { get; set; }
    public string Hinweis { get; set; } = string.Empty;
}
