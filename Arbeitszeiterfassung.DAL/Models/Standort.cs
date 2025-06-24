/*
Titel: Standort Entity
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Models/Standort.cs
Beschreibung: Standorte des Unternehmens
*/

using System.ComponentModel.DataAnnotations;

namespace Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Unternehmensstandort mit IP Range.
/// </summary>
public class Standort : BaseEntity
{
    [Key]
    public int StandortId { get; set; }

    [Required, MaxLength(100)]
    public string Bezeichnung { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? Adresse { get; set; }

    [MaxLength(50)]
    public string? IPRangeStart { get; set; }

    [MaxLength(50)]
    public string? IPRangeEnd { get; set; }

    public virtual List<BenutzerStandort> BenutzerStandorte { get; set; } = new();
}
