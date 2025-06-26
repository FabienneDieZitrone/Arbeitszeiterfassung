/*
Titel: INetworkMonitor Interface
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Interfaces/INetworkMonitor.cs
Beschreibung: Ueberwacht die Netzwerkverbindung.
*/

namespace Arbeitszeiterfassung.DAL.Interfaces;

/// <summary>
/// Schnittstelle zur Ueberwachung des Online-Status.
/// </summary>
public interface INetworkMonitor
{
    bool IsOnline { get; }
    event EventHandler<NetworkStatusEventArgs>? NetworkStatusChanged;

    Task StartMonitoringAsync();
    Task StopMonitoringAsync();
    Task<bool> CheckConnectivityAsync();
}

/// <summary>
/// Ereignisargumente fuer Netzwerkstatus.
/// </summary>
public class NetworkStatusEventArgs : EventArgs
{
    public bool IsOnline { get; init; }
}
