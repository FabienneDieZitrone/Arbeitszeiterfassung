/*
Titel: Basisklasse fuer Entities
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Models/BaseEntity.cs
Beschreibung: Gemeinsame Eigenschaften fuer alle Entitaeten
*/

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Basisklasse mit gemeinsamen Feldern und INotifyPropertyChanged.
/// </summary>
public abstract class BaseEntity : INotifyPropertyChanged, IValidatableObject
{
    /// <summary>Aktiv-Flag fuer Soft-Delete.</summary>
    public bool Aktiv { get; set; } = true;

    /// <summary>Erstellt am.</summary>
    public DateTime ErstelltAm { get; set; } = DateTime.UtcNow;

    /// <summary>Geaendert am.</summary>
    public DateTime? GeaendertAm { get; set; }

    /// <summary>Geaendert von.</summary>
    public string? GeaendertVon { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        yield break;
    }
}
