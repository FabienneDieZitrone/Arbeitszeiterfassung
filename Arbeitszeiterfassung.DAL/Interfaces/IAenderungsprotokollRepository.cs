/*
Titel: IAenderungsprotokollRepository
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Interfaces/IAenderungsprotokollRepository.cs
Beschreibung: Repository-Interface fuer Aenderungsprotokolle.
*/

using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.DAL.Interfaces;

/// <summary>
/// Zugriffsmethoden fuer das Aenderungsprotokoll.
/// </summary>
public interface IAenderungsprotokollRepository : IRepository<Aenderungsprotokoll>
{
    Task<IEnumerable<Aenderungsprotokoll>> GetUngenehmigteAenderungenAsync();
}
