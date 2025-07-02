/*
Titel: IArbeitszeitRepository
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Interfaces/IArbeitszeitRepository.cs
Beschreibung: Repository-Interface fuer Arbeitszeiten.
*/

using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.DAL.Interfaces;

/// <summary>
/// Spezifische Datenzugriffsmethoden fuer Arbeitszeitdaten.
/// </summary>
public interface IArbeitszeitRepository : IRepository<Arbeitszeit>
{
    Task<Arbeitszeit?> GetAktuelleArbeitszeitAsync(int benutzerId);
}
