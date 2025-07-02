/*
Titel: ArbeitszeitValidator
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Validators/ArbeitszeitValidator.cs
Beschreibung: Validiert Start- und Stoppzeiten
*/

using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.BLL.Models;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Validators;

/// <summary>
/// Basisvalidierungen fuer Arbeitszeiten.
/// </summary>
public class ArbeitszeitValidator : IArbeitszeitValidator
{
    public ValidationResult ValidateStart(Benutzer benutzer, Standort standort)
    {
        var result = new ValidationResult();
        if (benutzer == null) result.Errors.Add("Benutzer unbekannt");
        if (standort == null) result.Errors.Add("Standort unbekannt");
        return result;
    }

    public ValidationResult ValidateStopp(Arbeitszeit arbeitszeit)
    {
        var result = new ValidationResult();
        if (arbeitszeit.Stopp <= arbeitszeit.Start)
            result.Errors.Add("Stoppzeit muss nach Startzeit liegen");
        if ((arbeitszeit.Stopp - arbeitszeit.Start).TotalHours > 12)
            result.Errors.Add("Arbeitszeit darf 12h nicht überschreiten");
        return result;
    }

    public ValidationResult ValidateZeitraum(DateTime start, DateTime stopp)
    {
        var result = new ValidationResult();
        if (stopp <= start)
            result.Errors.Add("Ungültiger Zeitraum");
        return result;
    }

    public ValidationResult ValidatePause(TimeSpan pausenzeit, TimeSpan arbeitszeit)
    {
        var result = new ValidationResult();
        if (pausenzeit > arbeitszeit)
            result.Errors.Add("Pause größer als Arbeitszeit");
        return result;
    }

    public ValidationResult ValidateWochenarbeitszeit(decimal istStunden, decimal sollStunden)
    {
        var result = new ValidationResult();
        if (istStunden > sollStunden * 1.5m)
            result.Errors.Add("Zu viele Stunden diese Woche");
        return result;
    }
}
