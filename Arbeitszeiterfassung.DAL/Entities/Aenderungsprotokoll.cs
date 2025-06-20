using System;
using System.ComponentModel.DataAnnotations;
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.DAL.Entities
{
    /// <summary>
    /// Protokolliert Änderungen an Arbeitszeiten.
    /// </summary>
    public class Aenderungsprotokoll : BaseEntity
    {
        [Key]
        public int AenderungsprotokollId { get; set; }

        public int BenutzerId { get; set; }
        public Benutzer? Benutzer { get; set; }

        public DateTime Zeitpunkt { get; set; }

        public AenderungsAktion Aktion { get; set; }
        public AenderungsGrund Grund { get; set; }

        [MaxLength(500)]
        public string? Beschreibung { get; set; }

        public bool Genehmigt { get; set; }
    }
}
