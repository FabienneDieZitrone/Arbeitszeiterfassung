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

    public AenderungsAktion Aktion { get; set; }
    public AenderungsGrund Grund { get; set; }

    [MaxLength(255)]
    public string? GrundText { get; set; }

    public bool Genehmigt { get; set; }
}
