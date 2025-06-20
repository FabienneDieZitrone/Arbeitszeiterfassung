using System.ComponentModel.DataAnnotations;
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.DAL.Entities
{
    /// <summary>
    /// Key-Value basierte Systemeinstellungen.
    /// </summary>
    public class Systemeinstellung : BaseEntity
    {
        [Key]
        public int SystemeinstellungId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Key { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? WertString { get; set; }
        public int? WertNumber { get; set; }
        public bool? WertBool { get; set; }
        public string? WertJson { get; set; }

        public EinstellungsTyp Typ { get; set; }
    }
}
