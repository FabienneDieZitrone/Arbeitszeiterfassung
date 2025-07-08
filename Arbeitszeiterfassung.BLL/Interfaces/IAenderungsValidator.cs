/*
Titel: IAenderungsValidator
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Interfaces/IAenderungsValidator.cs
Beschreibung: Validiert beantragte Arbeitszeitaenderungen
*/
using Arbeitszeiterfassung.DAL.Models;
using Arbeitszeiterfassung.BLL.Models;

namespace Arbeitszeiterfassung.BLL.Interfaces;

/// <summary>
/// Schnittstelle fuer die Validierung von Arbeitszeitaenderungen.
/// </summary>
public interface IAenderungsValidator
{
    Task<ValidationResult> ValidateAenderungAsync(Arbeitszeit original, ArbeitszeitAenderung aenderung);
}
