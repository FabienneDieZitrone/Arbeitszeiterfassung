/*
Titel: Benutzer.cs
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Entities/Benutzer.cs
Beschreibung: Entity-Klasse für Benutzer mit Audit- und Navigationsinformationen.
*/

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.DAL.Entities;

/// <summary>
/// Repräsentiert einen Benutzer der Anwendung.
/// </summary>
public partial class Benutzer : INotifyPropertyChanged, IValidatableObject
{
    [Key]
    public int BenutzerId { get; set; }

    [Required, MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? Vorname { get; set; }

    [MaxLength(100)]
    public string? Nachname { get; set; }

    [MaxLength(255)]
    public string? Email { get; set; }

    public int RolleId { get; set; }
    public Rolle? Rolle { get; set; }

    public bool Aktiv { get; set; } = true;

    public DateTime ErstelltAm { get; set; } = DateTime.UtcNow;
    public DateTime? GeaendertAm { get; set; }
    public int? GeaendertVon { get; set; }

    public Stammdaten? Stammdaten { get; set; }
    public ICollection<Arbeitszeit> Arbeitszeiten { get; set; } = new List<Arbeitszeit>();
    public ICollection<BenutzerStandort> BenutzerStandorte { get; set; } = new List<BenutzerStandort>();

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /// <summary>
    /// Validiert die Benutzerdaten.
    /// </summary>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Username))
        {
            yield return new ValidationResult("Username darf nicht leer sein", new[] { nameof(Username) });
        }
    }
}
