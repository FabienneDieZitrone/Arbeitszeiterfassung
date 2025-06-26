/*
Titel: IBenutzerRepository
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Interfaces/IBenutzerRepository.cs
Beschreibung: Repository-Interface fuer Benutzer-spezifische Abfragen.
*/

using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.DAL.Interfaces;

/// <summary>
/// Spezifische Datenzugriffsmethoden fuer Benutzer.
/// </summary>
public interface IBenutzerRepository : IRepository<Benutzer>
{
    Task<Benutzer?> GetBenutzerByUsernameAsync(string username);
}
