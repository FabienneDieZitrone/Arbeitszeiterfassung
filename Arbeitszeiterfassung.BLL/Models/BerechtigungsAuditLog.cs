/*
Titel: BerechtigungsAuditLog
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Models/BerechtigungsAuditLog.cs
Beschreibung: Eintrag fuer das Berechtigungs-Audit-Log
*/

namespace Arbeitszeiterfassung.BLL.Models;

/// <summary>
/// Repraesentiert einen Berechtigungspruefungs-Eintrag.
/// </summary>
public class BerechtigungsAuditLog
{
    public int Id { get; set; }
    public int BenutzerID { get; set; }
    public string Permission { get; set; } = string.Empty;
    public bool Granted { get; set; }
    public string Context { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public Guid SessionID { get; set; }
}
