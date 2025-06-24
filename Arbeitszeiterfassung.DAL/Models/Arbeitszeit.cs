/*
Titel: Arbeitszeit Entity
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Models/Arbeitszeit.cs
Beschreibung: Erfasste Arbeitszeiten eines Benutzers
*/

using System.ComponentModel.DataAnnotations;

namespace Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Einzelner Arbeitszeiteintrag.
/// </summary>
public partial class Arbeitszeit : BaseEntity
{
    [Key]
    public int ArbeitszeitId { get; set; }

    public int BenutzerId { get; set; }
    public virtual Benutzer? Benutzer { get; set; }

    public DateTime Start { get; set; }
    public DateTime Stopp { get; set; }
    public TimeSpan Pause { get; set; }

    public bool IstOfflineErfasst { get; set; }
    public bool IstSynchronisiert { get; set; }
}
