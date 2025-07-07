/*
Titel: ArbeitszeitStatus
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Models/ArbeitszeitStatus.cs
Beschreibung: Modell zur Darstellung des aktuellen Zeiterfassungsstatus
*/

namespace Arbeitszeiterfassung.BLL.Models;

/// <summary>
/// Abbild des aktuellen Zeiterfassungsstatus eines Benutzers.
/// </summary>
public class ArbeitszeitStatus
{
    public bool IstAktiv { get; set; }
    public DateTime? AktuellerStart { get; set; }
    public TimeSpan BisherigeArbeitszeit { get; set; }
    public decimal TagesSoll { get; set; }
    public decimal TagesIst { get; set; }
    public decimal WochenSoll { get; set; }
    public decimal WochenIst { get; set; }
    public decimal Ueberstunden { get; set; }
    public List<string> Warnungen { get; set; } = new();
}
