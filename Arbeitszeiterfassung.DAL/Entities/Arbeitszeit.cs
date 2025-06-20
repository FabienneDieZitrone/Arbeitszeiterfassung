/*
Titel: Arbeitszeit.cs
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Entities/Arbeitszeit.cs
Beschreibung: Zeiterfassungsdaten eines Benutzers mit berechneten Feldern.
*/

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arbeitszeiterfassung.DAL.Entities;

/// <summary>
/// Zeiterfassungseintrag eines Benutzers.
/// </summary>
public partial class Arbeitszeit : INotifyPropertyChanged, IValidatableObject
{
    [Key]
    public int ArbeitszeitId { get; set; }

    public int BenutzerId { get; set; }
    public Benutzer? Benutzer { get; set; }

    [Required]
    public DateOnly Datum { get; set; }

    [Required]
    public DateTime Startzeit { get; set; }

    public DateTime? Stoppzeit { get; set; }

    public TimeSpan Pausenzeit { get; set; } = TimeSpan.Zero;

    public int StandortId { get; set; }
    public Standort? Standort { get; set; }

    public bool IstOffline { get; set; }
    public DateTime? SynchronisiertAm { get; set; }

    public DateTime ErstelltAm { get; set; } = DateTime.UtcNow;
    public DateTime? GeaendertAm { get; set; }
    public int? GeaendertVon { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    [NotMapped]
    public TimeSpan Gesamtzeit => (Stoppzeit ?? DateTime.UtcNow) - Startzeit;

    [NotMapped]
    public TimeSpan ArbeitszeitDauer => Gesamtzeit - Pausenzeit;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Stoppzeit.HasValue && Stoppzeit <= Startzeit)
        {
            yield return new ValidationResult("Stoppzeit muss nach Startzeit liegen", new[] { nameof(Stoppzeit) });
        }
    }
}
