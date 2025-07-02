/*
Titel: IStandortService
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Interfaces/IStandortService.cs
Beschreibung: Schnittstelle fuer Standortfunktionen
*/

namespace Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Bietet Methoden zur Standortermittlung und Cache-Verwaltung.
/// </summary>
public interface IStandortService
{
    /// <summary>Lädt alle Standorte aus der Datenbank.</summary>
    Task<List<Standort>> LoadStandorteAsync();

    /// <summary>Gibt einen Standort anhand der IP-Adresse zurueck.</summary>
    Task<Standort?> FindByIPAsync(string ipAddress);
}
