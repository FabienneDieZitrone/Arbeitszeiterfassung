/*
Titel: EskalationsManager
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Workflow/EskalationsManager.cs
Beschreibung: Kuemmert sich um Eskalationen
*/
using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;
using System.Linq;

namespace Arbeitszeiterfassung.BLL.Workflow;

/// <summary>
/// Einfache Platzhalterimplementierung des Eskalationsmanagers.
/// </summary>
public class EskalationsManager : IEskalationsManager
{
    private readonly IGenehmigungService service;
    private readonly INotificationService notification;

    public EskalationsManager(IGenehmigungService service, INotificationService notification)
    {
        this.service = service;
        this.notification = notification;
    }

    public async Task PruefeUndEskaliereAsync()
    {
        var offene = await service.GetOffeneAntraegeAsync(0);
        foreach (var antrag in offene.Where(a => (DateTime.UtcNow - a.GeaendertAm).TotalDays > 5))
        {
            var bereichsleiter = new Benutzer { BenutzerId = 0 };
            await notification.SendeEskalationAsync(antrag, bereichsleiter);
        }
    }
}
