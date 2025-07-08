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
        if (aenderung.NeueStartzeit.HasValue && aenderung.NeueStoppzeit.HasValue &&
            aenderung.NeueStartzeit >= aenderung.NeueStoppzeit)
        {
            result.Errors.Add("Stoppzeit muss nach Startzeit liegen");
        }
        return Task.FromResult(result);
    }
}
