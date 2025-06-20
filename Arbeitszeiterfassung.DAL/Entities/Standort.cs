using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arbeitszeiterfassung.DAL.Entities
{
    /// <summary>
    /// Standort eines Unternehmens.
    /// </summary>
    public class Standort : BaseEntity
    {
        [Key]
        public int StandortId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Bezeichnung { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Adresse { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? IPRangeStart { get; set; }

        [MaxLength(50)]
        public string? IPRangeEnd { get; set; }

        public ICollection<BenutzerStandort> BenutzerStandorte { get; set; } = new List<BenutzerStandort>();
    }
}
