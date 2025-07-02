/*
Titel: IArbeitszeitValidator
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Interfaces/IArbeitszeitValidator.cs
Beschreibung: Schnittstelle fuer Validierungslogik der Zeiterfassung
*/

using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Interfaces;

/// <summary>
/// Validiert Arbeitszeiterfassungsoperationen.
/// </summary>
public interface IArbeitszeitValidator
{
    ValidationResult ValidateStart(Benutzer benutzer, Standort standort);
    ValidationResult ValidateStopp(Arbeitszeit arbeitszeit);
    ValidationResult ValidateZeitraum(DateTime start, DateTime stopp);
    ValidationResult ValidatePause(TimeSpan pausenzeit, TimeSpan arbeitszeit);
    ValidationResult ValidateWochenarbeitszeit(decimal istStunden, decimal sollStunden);
}
