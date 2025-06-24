/*
Titel: Stammdaten Entity
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Models/Stammdaten.cs
Beschreibung: Stammdaten zu Arbeitszeiten eines Benutzers
*/

using System.ComponentModel.DataAnnotations;

namespace Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Enthält persoenliche Stammdaten eines Benutzers.
/// </summary>
public class Stammdaten : BaseEntity
{
    [Key]
    public int StammdatenId { get; set; }

    public int BenutzerId { get; set; }
    public virtual Benutzer? Benutzer { get; set; }

    public decimal Wochenarbeitszeit { get; set; }

    public bool ArbeitstagMo { get; set; }
    public bool ArbeitstagDi { get; set; }
    public bool ArbeitstagMi { get; set; }
    public bool ArbeitstagDo { get; set; }
    public bool ArbeitstagFr { get; set; }

    public bool HomeOfficeErlaubt { get; set; }
}
