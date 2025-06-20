using System.ComponentModel.DataAnnotations;

namespace Arbeitszeiterfassung.DAL.Entities
{
    /// <summary>
    /// Stammdaten eines Benutzers.
    /// </summary>
    public class Stammdaten : BaseEntity
    {
        [Key]
        public int StammdatenId { get; set; }

        [Range(0, 100)]
        public double Wochenarbeitszeit { get; set; }

        public bool Montag { get; set; }
        public bool Dienstag { get; set; }
        public bool Mittwoch { get; set; }
        public bool Donnerstag { get; set; }
        public bool Freitag { get; set; }

        public bool HomeOfficeErlaubt { get; set; }

        public int BenutzerId { get; set; }
        public Benutzer? Benutzer { get; set; }
    }
}
