/*
Titel: BenutzerStandort Entity
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Models/BenutzerStandort.cs
Beschreibung: Verknuepfung zwischen Benutzer und Standort
*/

using System.ComponentModel.DataAnnotations;

namespace Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Viele-zu-Viele-Beziehung zwischen Benutzern und Standorten.
/// </summary>
public class BenutzerStandort : BaseEntity
{
    public int BenutzerId { get; set; }
    public virtual Benutzer? Benutzer { get; set; }

    public int StandortId { get; set; }
    public virtual Standort? Standort { get; set; }

    public bool IstHauptstandort { get; set; }
    public DateTime ZugewiesenAm { get; set; } = DateTime.UtcNow;
}
