/*
Titel: ISessionManager
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Interfaces/ISessionManager.cs
Beschreibung: Schnittstelle fuer Sitzungsverwaltung
*/

namespace Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Verwaltet die aktuelle Benutzersitzung.
/// </summary>
public interface ISessionManager
{
    /// <summary>Aktueller Benutzer der Session.</summary>
    Benutzer? CurrentUser { get; }

    /// <summary>Startet eine neue Session fuer den angegebenen Benutzer.</summary>
    void StartSession(Benutzer benutzer);

    /// <summary>Beendet die aktuelle Session.</summary>
    void EndSession();
}
