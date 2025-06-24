/*
Titel: Rolle Entity
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Models/Rolle.cs
Beschreibung: Benutzerrollen des Systems
*/

using System.ComponentModel.DataAnnotations;
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Definiert eine Benutzerrolle.
/// </summary>
public class Rolle : BaseEntity
{
    [Key]
    public int RolleId { get; set; }

    [Required, MaxLength(100)]
    public string Bezeichnung { get; set; } = string.Empty;

    public Berechtigungsstufe Berechtigungsstufe { get; set; }

    [MaxLength(255)]
    public string? Beschreibung { get; set; }

    public virtual List<Benutzer> Benutzer { get; set; } = new();
}
