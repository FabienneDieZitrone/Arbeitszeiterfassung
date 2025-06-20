/*
Titel: BenutzerStandort.cs
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Entities/BenutzerStandort.cs
Beschreibung: Zwischentabelle zur Zuordnung von Benutzern zu Standorten.
*/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arbeitszeiterfassung.DAL.Entities;

/// <summary>
/// Verknüpft Benutzer mit Standorten (n:m).
/// </summary>
public class BenutzerStandort
{
    [Key, Column(Order = 0)]
    public int BenutzerId { get; set; }
    public Benutzer? Benutzer { get; set; }

    [Key, Column(Order = 1)]
    public int StandortId { get; set; }
    public Standort? Standort { get; set; }

    public bool IstHauptstandort { get; set; }
    public DateTime ZugewiesenAm { get; set; } = DateTime.UtcNow;
    public int ZugewiesenVon { get; set; }
}
