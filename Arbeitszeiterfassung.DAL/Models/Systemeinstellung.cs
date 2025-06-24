/*
Titel: Systemeinstellung Entity
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Models/Systemeinstellung.cs
Beschreibung: Key-Value-Konfiguration
*/

using System.ComponentModel.DataAnnotations;
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Key-Value basierte Konfiguration der Anwendung.
/// </summary>
public class Systemeinstellung : BaseEntity
{
    [Key]
    public int SystemeinstellungId { get; set; }

    [Required, MaxLength(100)]
    public string Schluessel { get; set; } = string.Empty;

    public EinstellungsTyp Typ { get; set; }

    public string? WertString { get; set; }
    public decimal? WertNumber { get; set; }
    public bool? WertBoolean { get; set; }
    public string? WertJson { get; set; }
}
