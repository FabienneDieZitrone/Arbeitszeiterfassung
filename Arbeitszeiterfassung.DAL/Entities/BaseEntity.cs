using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Arbeitszeiterfassung.DAL.Entities
{
    /// <summary>
    /// Basisklasse für alle Datenbankentitäten mit Audit-Feldern.
    /// </summary>
    public abstract class BaseEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gibt an, ob der Datensatz aktiv ist (Soft-Delete).
        /// </summary>
        public bool Aktiv { get; set; } = true;

        /// <summary>
        /// Zeitpunkt der Erstellung des Datensatzes.
        /// </summary>
        [Required]
        public DateTime ErstelltAm { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Zeitpunkt der letzten Änderung.
        /// </summary>
        public DateTime? GeaendertAm { get; set; }

        /// <summary>
        /// Benutzername der letzten Änderung.
        /// </summary>
        public string? GeaendertVon { get; set; }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
