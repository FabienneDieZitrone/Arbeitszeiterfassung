using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arbeitszeiterfassung.DAL.Entities
{
    /// <summary>
    /// Erfasste Arbeitszeit eines Benutzers.
    /// </summary>
    public partial class Arbeitszeit : BaseEntity, IValidatableObject
    {
        [Key]
        public int ArbeitszeitId { get; set; }

        public int BenutzerId { get; set; }
        public Benutzer? Benutzer { get; set; }

        [Required]
        public DateTime Start { get; set; }

        public DateTime? Stopp { get; set; }

        public TimeSpan? Pausen { get; set; }

        public bool OfflineErfasst { get; set; }

        public bool Synchronisiert { get; set; }

        [NotMapped]
        public TimeSpan? Gesamtzeit => (Stopp.HasValue ? Stopp.Value - Start : TimeSpan.Zero) - (Pausen ?? TimeSpan.Zero);

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Stopp.HasValue && Stopp < Start)
            {
                yield return new ValidationResult("Stopp darf nicht vor Start liegen", new[] { nameof(Stopp) });
            }
        }
    }
}
