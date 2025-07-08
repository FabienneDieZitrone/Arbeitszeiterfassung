/*
Titel: NotificationService
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Services/NotificationService.cs
Beschreibung: Implementierung des Benachrichtigungssystems
*/
using System;
using System.Collections.Generic;
using System.Linq;
using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Services;

/// <summary>
/// Einfache Implementierung des Benachrichtigungsservices.
/// </summary>
public class NotificationService : INotificationService
{
    public Task SendeGenehmigungsanfrageAsync(Aenderungsprotokoll antrag, Benutzer genehmiger)
    {
        Console.WriteLine($"Genehmigungsanfrage an {genehmiger.BenutzerId} für Änderung {antrag.AenderungsprotokollId}");
        return Task.CompletedTask;
    }

    public Task SendeGenehmigungsentscheidungAsync(Aenderungsprotokoll antrag, bool genehmigt)
    {
        Console.WriteLine($"Genehmigungsentscheidung für {antrag.AenderungsprotokollId}: {(genehmigt ? "genehmigt" : "abgelehnt")}");
        return Task.CompletedTask;
    }

    public Task SendeEskalationAsync(Aenderungsprotokoll antrag, Benutzer neuerGenehmiger)
    {
        Console.WriteLine($"Eskalation an {neuerGenehmiger.BenutzerId} für Änderung {antrag.AenderungsprotokollId}");
        return Task.CompletedTask;
    }

    public Task SendeErinnerungAsync(IEnumerable<Aenderungsprotokoll> offeneAntraege)
    {
        Console.WriteLine($"Erinnerung für {offeneAntraege.Count()} offene Anträge");
        return Task.CompletedTask;
    }
}
