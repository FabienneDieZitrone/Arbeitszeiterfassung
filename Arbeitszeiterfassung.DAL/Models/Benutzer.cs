/*
Titel: Benutzer Entity
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Models/Benutzer.cs
Beschreibung: Datenbankmodell fuer Benutzer
*/

using System.ComponentModel.DataAnnotations;
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Repraesentiert einen Benutzer des Systems.
/// </summary>
public partial class Benutzer : BaseEntity
{
    [Key]
    public int BenutzerId { get; set; }

    [Required, MaxLength(100)]
    public string Username { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? Vorname { get; set; }

    [MaxLength(100)]
    public string? Nachname { get; set; }

    [MaxLength(255)]
    public string? Email { get; set; }

    public int RolleId { get; set; }
    public virtual Rolle? Rolle { get; set; }

    public virtual Stammdaten? Stammdaten { get; set; }
    public virtual List<Arbeitszeit> Arbeitszeiten { get; set; } = new();
    public virtual List<BenutzerStandort> BenutzerStandorte { get; set; } = new();

    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Username))
            yield return new ValidationResult("Username erforderlich", new[] { nameof(Username) });
        yield break;
    }
}
