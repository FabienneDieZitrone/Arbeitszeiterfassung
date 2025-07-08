/*
Titel: NotificationService
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Services/NotificationService.cs
Beschreibung: Implementierung des Benachrichtigungssystems
*/
using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Services;

/// <summary>
/// Einfache Implementierung des Benachrichtigungsservices.
/// </summary>
public class NotificationService : INotificationService
{
    public Task SendeGenehmigungsanfrageAsync(Aenderungsprotokoll antrag, Benutzer genehmiger)
        => Task.CompletedTask;

    public Task SendeGenehmigungsentscheidungAsync(Aenderungsprotokoll antrag, bool genehmigt)
        => Task.CompletedTask;

    public Task SendeEskalationAsync(Aenderungsprotokoll antrag, Benutzer neuerGenehmiger)
        => Task.CompletedTask;

    public Task SendeErinnerungAsync(IEnumerable<Aenderungsprotokoll> offeneAntraege)
        => Task.CompletedTask;
}
