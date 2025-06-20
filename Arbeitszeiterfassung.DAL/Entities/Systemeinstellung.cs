/*
Titel: Systemeinstellung.cs
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Entities/Systemeinstellung.cs
Beschreibung: Key-Value Konfigurationseintrag der Anwendung.
*/

using System.ComponentModel.DataAnnotations;
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.DAL.Entities;

/// <summary>
/// Key-Value basierte Systemeinstellung.
/// </summary>
public class Systemeinstellung
{
    [Key]
    public int EinstellungId { get; set; }

    [Required, MaxLength(100)]
    public string Schluessel { get; set; } = string.Empty;

    public string? Wert { get; set; }

    public EinstellungsTyp Typ { get; set; }

    public string? Beschreibung { get; set; }

    public DateTime? GeaendertAm { get; set; }
    public int? GeaendertVon { get; set; }
}
