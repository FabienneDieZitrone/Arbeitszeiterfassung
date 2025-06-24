/*
Titel: Benutzer Calculated Properties
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Models/Benutzer.Calculated.cs
Beschreibung: Erweiterungsklasse fuer berechnete Properties
*/

namespace Arbeitszeiterfassung.DAL.Models;

public partial class Benutzer
{
    /// <summary>Gibt den kompletten Namen zurueck.</summary>
    public string VollerName => string.Join(" ", new[] { Vorname, Nachname }.Where(s => !string.IsNullOrWhiteSpace(s)));
}
