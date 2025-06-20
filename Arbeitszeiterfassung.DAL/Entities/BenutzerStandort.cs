using System;
using System.ComponentModel.DataAnnotations;

namespace Arbeitszeiterfassung.DAL.Entities
{
    /// <summary>
    /// Zuordnung eines Benutzers zu einem Standort.
    /// </summary>
    public class BenutzerStandort : BaseEntity
    {
        public int BenutzerId { get; set; }
        public Benutzer? Benutzer { get; set; }

        public int StandortId { get; set; }
        public Standort? Standort { get; set; }

        public bool IstHauptstandort { get; set; }

        public DateTime Von { get; set; }
        public DateTime? Bis { get; set; }
    }
}
