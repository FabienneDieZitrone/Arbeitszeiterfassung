/*
Titel: Standort.cs
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Entities/Standort.cs
Beschreibung: Entity-Klasse für Standorte mit IP-Bereichen.
*/

using System.ComponentModel.DataAnnotations;

namespace Arbeitszeiterfassung.DAL.Entities;

/// <summary>
/// Repräsentiert einen Standort des Unternehmens.
/// </summary>
public class Standort
{
    [Key]
    public int StandortId { get; set; }

    [MaxLength(100)]
    public string? Bezeichnung { get; set; }

    [MaxLength(255)]
    public string? Adresse { get; set; }

    [MaxLength(15)]
    public string? IPRangeStart { get; set; }

    [MaxLength(15)]
    public string? IPRangeEnd { get; set; }

    public bool Aktiv { get; set; } = true;

    public ICollection<BenutzerStandort> BenutzerStandorte { get; set; } = new List<BenutzerStandort>();
    public ICollection<Arbeitszeit> Arbeitszeiten { get; set; } = new List<Arbeitszeit>();
}
