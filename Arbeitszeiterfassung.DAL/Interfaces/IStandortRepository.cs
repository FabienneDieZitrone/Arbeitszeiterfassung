/*
Titel: IStandortRepository
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Interfaces/IStandortRepository.cs
Beschreibung: Repository-Interface fuer Standorte.
*/

using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.DAL.Interfaces;

/// <summary>
/// Methoden zum Zugriff auf Standortdaten.
/// </summary>
public interface IStandortRepository : IRepository<Standort>
{
    Task<Standort?> GetByBezeichnungAsync(string name);
}
