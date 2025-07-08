/*
Titel: WorkflowStatus
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Models/WorkflowStatus.cs
Beschreibung: Statusinformationen zu Aenderungsantraegen
*/
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.BLL.Models;

/// <summary>
/// Speichert den Bearbeitungsstatus eines Aenderungsantrags.
/// </summary>
public class WorkflowStatus
{
    public int AenderungsprotokollID { get; set; }
    public GenehmigungStatus Status { get; set; }
    public DateTime ErstelltAm { get; set; }
    public DateTime? BearbeitetAm { get; set; }
    public int? BearbeitetVon { get; set; }
    public string? Kommentar { get; set; }
    public int EskalationsStufe { get; set; }
    public DateTime? NaechsteEskalation { get; set; }
}
