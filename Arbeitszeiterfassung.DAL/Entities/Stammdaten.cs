/*
Titel: Stammdaten.cs
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Entities/Stammdaten.cs
Beschreibung: Stammdaten eines Benutzers mit Wochenarbeitszeit und Arbeitstagen.
*/

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Arbeitszeiterfassung.DAL.Entities;

/// <summary>
/// Stammdaten eines Benutzers.
/// </summary>
public class Stammdaten : INotifyPropertyChanged, IValidatableObject
{
    [Key]
    public int StammdatenId { get; set; }

    public int BenutzerId { get; set; }
    public Benutzer? Benutzer { get; set; }

    [Range(0, 60)]
    public decimal Wochenarbeitszeit { get; set; }

    public bool Arbeitstag_Mo { get; set; }
    public bool Arbeitstag_Di { get; set; }
    public bool Arbeitstag_Mi { get; set; }
    public bool Arbeitstag_Do { get; set; }
    public bool Arbeitstag_Fr { get; set; }

    public bool HomeOfficeErlaubt { get; set; }

    public DateTime? GeaendertAm { get; set; }
    public int? GeaendertVon { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Wochenarbeitszeit < 0 || Wochenarbeitszeit > 60)
        {
            yield return new ValidationResult("Wochenarbeitszeit muss zwischen 0 und 60 liegen", new[] { nameof(Wochenarbeitszeit) });
        }
    }
}
