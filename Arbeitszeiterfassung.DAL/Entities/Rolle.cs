using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.DAL.Entities
{
    /// <summary>
    /// Benutzerrolle mit Berechtigungsstufe.
    /// </summary>
    public class Rolle : BaseEntity
    {
        [Key]
        public int RolleId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Bezeichnung { get; set; } = string.Empty;

        [Required]
        public Berechtigungsstufe Berechtigungsstufe { get; set; }

        [MaxLength(200)]
        public string? Beschreibung { get; set; }

        public ICollection<Benutzer> Benutzer { get; set; } = new List<Benutzer>();
    }
}
