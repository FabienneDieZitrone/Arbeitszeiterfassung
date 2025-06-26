/*
Titel: IUnitOfWork
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Interfaces/IUnitOfWork.cs
Beschreibung: Definiert die Unit-of-Work Schnittstelle.
*/

namespace Arbeitszeiterfassung.DAL.Interfaces;

/// <summary>
/// Kapselt den Zugriff auf Repositories und DB-Transaktionen.
/// </summary>
public interface IUnitOfWork : IAsyncDisposable
{
    IBenutzerRepository Benutzer { get; }
    IArbeitszeitRepository Arbeitszeiten { get; }
    IStandortRepository Standorte { get; }
    IAenderungsprotokollRepository Aenderungsprotokolle { get; }

    Task<int> SaveChangesAsync();
}
