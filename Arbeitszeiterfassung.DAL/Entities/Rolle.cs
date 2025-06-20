/*
Titel: Rolle.cs
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Entities/Rolle.cs
Beschreibung: Entity-Klasse für Benutzerrollen und ihre Berechtigungsstufe.
*/

using System.ComponentModel.DataAnnotations;
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.DAL.Entities;

/// <summary>
/// Rolle eines Benutzers mit Berechtigungsstufe.
/// </summary>
public class Rolle
{
    [Key]
    public int RolleId { get; set; }

    [Required, MaxLength(50)]
    public string Bezeichnung { get; set; } = string.Empty;

    public Berechtigungsstufe Berechtigungsstufe { get; set; }

    public string? Beschreibung { get; set; }

    public ICollection<Benutzer> Benutzer { get; set; } = new List<Benutzer>();
}
