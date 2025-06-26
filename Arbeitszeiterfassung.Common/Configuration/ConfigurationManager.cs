/*
Titel: ConfigurationManager
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Configuration/ConfigurationManager.cs
Beschreibung: Zentrale Klasse zum Laden und Verwalten der App-Konfiguration.
*/

using Arbeitszeiterfassung.Common.Configuration.Models;
using Arbeitszeiterfassung.Common.Helpers;
using SysConfig = System.Configuration.ConfigurationManager;

namespace Arbeitszeiterfassung.Common.Configuration;

/// <summary>
/// Singleton zum Zugriff auf die Anwendungskonfiguration.
/// </summary>
public sealed class ConfigurationManager
{
    private static readonly Lazy<ConfigurationManager> instance = new(() => new ConfigurationManager());

    private ConfigurationManager()
    {
        Load();
    }

    public static ConfigurationManager Instance => instance.Value;

    public AppSettings Settings { get; private set; } = new();

    /// <summary>
    /// Laedt die Einstellungen aus der App.config.
    /// </summary>
    public void Load()
    {
        Settings.Database.MainConnectionString = SysConfig.ConnectionStrings["DefaultConnection"].ConnectionString;
        Settings.Database.OfflineConnectionString = SysConfig.ConnectionStrings["OfflineConnection"].ConnectionString;
    }
}
