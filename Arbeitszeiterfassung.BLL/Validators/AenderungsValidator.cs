/*
Titel: AenderungsValidator
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Validators/AenderungsValidator.cs
Beschreibung: Validiert beantragte Aenderungen
*/
using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.BLL.Models;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Validators;

/// <summary>
/// Basisvalidierung fuer Arbeitszeitaenderungen.
/// </summary>
public class AenderungsValidator : IAenderungsValidator
{
    public Task<ValidationResult> ValidateAenderungAsync(Arbeitszeit original, ArbeitszeitAenderung aenderung)
    {
        ValidationResult result = new();

        if (aenderung.NeueStartzeit.HasValue && aenderung.NeueStoppzeit.HasValue)
        {
            if (aenderung.NeueStartzeit >= aenderung.NeueStoppzeit)
                result.Errors.Add("Stoppzeit muss nach Startzeit liegen");

            var dauer = aenderung.NeueStoppzeit.Value - aenderung.NeueStartzeit.Value;
            if (dauer.TotalHours > 12)
                result.Errors.Add("Arbeitszeit darf 12 Stunden nicht überschreiten");
        }

        // Rueckwirkende Aenderungen nur bis 7 Tage
        var tageZurueck = (DateTime.Today - original.Start.Date).Days;
        if (tageZurueck > 7)
            result.Errors.Add("Änderungen sind nur bis 7 Tage rückwirkend möglich");

        return Task.FromResult(result);
    }
}
