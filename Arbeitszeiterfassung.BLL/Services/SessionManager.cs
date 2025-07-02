/*
Titel: SessionManager
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Services/SessionManager.cs
Beschreibung: Singleton zur Verwaltung der Benutzersitzung
*/
using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Services;

/// <summary>
/// Thread-sicherer Singleton zur Verwaltung der aktuellen Session.
/// </summary>
public sealed class SessionManager : ISessionManager
{
    private static readonly Lazy<SessionManager> lazy = new(() => new SessionManager());
    private readonly object syncRoot = new();

    private SessionManager() { }

    /// <summary>Instanz des SessionManagers.</summary>
    public static SessionManager Instance => lazy.Value;

    public Benutzer? CurrentUser { get; private set; }

    public void StartSession(Benutzer benutzer)
    {
        lock (syncRoot)
        {
            CurrentUser = benutzer;
        }
    }

    public void EndSession()
    {
        lock (syncRoot)
        {
            CurrentUser = null;
        }
    }
}
