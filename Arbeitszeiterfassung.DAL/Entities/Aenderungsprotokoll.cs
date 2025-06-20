/*
Titel: Aenderungsprotokoll.cs
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Entities/Aenderungsprotokoll.cs
Beschreibung: Entity-Klasse für das Änderungsprotokoll von Arbeitszeiten.
*/

using System.ComponentModel.DataAnnotations;
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.DAL.Entities;

/// <summary>
/// Protokolliert Änderungen an Arbeitszeit-Einträgen.
/// </summary>
public class Aenderungsprotokoll
{
    [Key]
    public int AenderungId { get; set; }

    public int OriginalId { get; set; }

    public int BenutzerId { get; set; }
    public Benutzer? Benutzer { get; set; }

    public DateOnly Datum { get; set; }
    public DateTime? Startzeit_Alt { get; set; }
    public DateTime? Startzeit_Neu { get; set; }
    public DateTime? Stoppzeit_Alt { get; set; }
    public DateTime? Stoppzeit_Neu { get; set; }
    public TimeSpan Gesamtzeit { get; set; }
    public TimeSpan Arbeitszeit { get; set; }
    public TimeSpan Pausenzeit { get; set; }
    public int StandortId { get; set; }
    public Standort? Standort { get; set; }
    public AenderungsAktion Aktion { get; set; }
    public AenderungsGrund Aenderungsgrund { get; set; }
    public string? AenderungsText { get; set; }
    public int? GeaendertVon { get; set; }
    public DateTime GeaendertAm { get; set; } = DateTime.UtcNow;
    public bool IstGenehmigt { get; set; }
    public int? GenehmigtVon { get; set; }
    public DateTime? GenehmigtAm { get; set; }
}
