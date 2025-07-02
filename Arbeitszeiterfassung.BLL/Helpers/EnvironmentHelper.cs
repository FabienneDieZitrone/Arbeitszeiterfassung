/*
Titel: EnvironmentHelper
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Helpers/EnvironmentHelper.cs
Beschreibung: Helfer zum Auslesen von Umgebungsinformationen
*/

using System.Net;
using System.Linq;
namespace Arbeitszeiterfassung.BLL.Helpers;

/// <summary>
/// Statische Methoden zum Abruf von Umgebungsdaten.
/// </summary>
public static class EnvironmentHelper
{
    /// <summary>Liefert den Windows-Benutzernamen.</summary>
    public static string GetWindowsUsername() => Environment.UserName;

    /// <summary>Ermittelt den Computernamen.</summary>
    public static string GetMachineName() => Environment.MachineName;

    /// <summary>Gibt die lokale IPv4-Adresse zurueck.</summary>
    public static string GetLocalIPAddress()
    {
        return Dns.GetHostEntry(Dns.GetHostName())
            .AddressList
            .First(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            .ToString();
    }
}
