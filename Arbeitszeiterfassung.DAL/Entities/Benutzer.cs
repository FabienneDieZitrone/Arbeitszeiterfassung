using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.DAL.Entities
{
    /// <summary>
    /// Benutzer der Anwendung.
    /// </summary>
    public class Benutzer : BaseEntity
    {
        [Key]
        public int BenutzerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Vorname { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Nachname { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        public int RolleId { get; set; }
        public Rolle? Rolle { get; set; }
        public Stammdaten? Stammdaten { get; set; }
        public ICollection<Arbeitszeit> Arbeitszeiten { get; set; } = new List<Arbeitszeit>();
        public ICollection<BenutzerStandort> BenutzerStandorte { get; set; } = new List<BenutzerStandort>();
    }
}
