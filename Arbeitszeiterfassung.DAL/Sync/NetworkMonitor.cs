/*
Titel: NetworkMonitor
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Sync/NetworkMonitor.cs
Beschreibung: Ueberwacht die Netzwerkverbindung.
*/
using System.Net.NetworkInformation;
using Arbeitszeiterfassung.DAL.Interfaces;

namespace Arbeitszeiterfassung.DAL.Sync;

/// <summary>
/// Implementierung des Netzwerktrackers.
/// </summary>
public class NetworkMonitor : INetworkMonitor
{
    public bool IsOnline { get; private set; }
    public event EventHandler<NetworkStatusEventArgs>? NetworkStatusChanged;

    public async Task StartMonitoringAsync()
    {
        await Task.Run(CheckConnectivityAsync);
    }

    public Task StopMonitoringAsync() => Task.CompletedTask;

    public async Task<bool> CheckConnectivityAsync()
    {
        bool online = NetworkInterface.GetIsNetworkAvailable();
        if (online != IsOnline)
        {
            IsOnline = online;
            NetworkStatusChanged?.Invoke(this, new NetworkStatusEventArgs { IsOnline = online });
        }
        await Task.CompletedTask;
        return online;
    }
}
