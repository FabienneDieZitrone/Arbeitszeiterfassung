/*
Titel: Aenderungsprotokoll Entity
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Models/Aenderungsprotokoll.cs
Beschreibung: Audit-Trail fuer Datenaenderungen
*/

using System.ComponentModel.DataAnnotations;
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Audit-Trail fuer Datenaenderungen.
/// </summary>
public class Aenderungsprotokoll : BaseEntity
{
    [Key]
    public int AenderungsprotokollId { get; set; }

    [MaxLength(100)]
    public string EntityName { get; set; } = string.Empty;

    public int? EntityId { get; set; }

    /// <summary>Referenz auf die urspruengliche Arbeitszeit.</summary>
    public int OriginalID { get; set; }

    /// <summary>Betroffener Benutzer.</summary>
    public int BenutzerID { get; set; }

    /// <summary>Datum der Arbeitszeit.</summary>
    public DateTime Datum { get; set; }

    /// <summary>Alte Startzeit.</summary>
    public DateTime Startzeit_Alt { get; set; }

    /// <summary>Neue Startzeit.</summary>
    public DateTime Startzeit_Neu { get; set; }

    /// <summary>Alte Stoppzeit.</summary>
    public DateTime Stoppzeit_Alt { get; set; }

    /// <summary>Neue Stoppzeit.</summary>
    public DateTime Stoppzeit_Neu { get; set; }

    /// <summary>Alte Pausenzeit.</summary>
    public TimeSpan Pausenzeit_Alt { get; set; }

    /// <summary>Neue Pausenzeit.</summary>
    public TimeSpan Pausenzeit_Neu { get; set; }

    /// <summary>Neuer Standort (optional).</summary>
    public int? StandortID { get; set; }

    /// <summary>Wer hat die Änderung beantragt?</summary>
    public int GeaendertVon { get; set; }

    /// <summary>Wann wurde die Änderung beantragt?</summary>
    public DateTime GeaendertAm { get; set; } = DateTime.UtcNow;

    public AenderungsAktion Aktion { get; set; }
    public AenderungsGrund Grund { get; set; }

    [MaxLength(255)]
    public string? GrundText { get; set; }

    /// <summary>Aktueller Genehmigungsstatus.</summary>
    public bool Genehmigt { get; set; }

    /// <summary>Genehmiger (optional).</summary>
    public int? GenehmigtVon { get; set; }

    /// <summary>Zeitpunkt der Genehmigung.</summary>
    public DateTime? GenehmigtAm { get; set; }
}
