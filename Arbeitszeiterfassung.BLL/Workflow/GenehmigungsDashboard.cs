/*
Titel: GenehmigungsDashboard
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Workflow/GenehmigungsDashboard.cs
Beschreibung: Aufbereitung der Dashboard-Daten
*/
using System;
using System.Linq;
using Arbeitszeiterfassung.BLL.Models;
using Arbeitszeiterfassung.BLL.Interfaces;

namespace Arbeitszeiterfassung.BLL.Workflow;

/// <summary>
/// Erstellt Daten fuer das Genehmigungsdashboard.
/// </summary>
public class GenehmigungsDashboard
{
    private readonly IGenehmigungService service;

    public GenehmigungsDashboard(IGenehmigungService service)
    {
        this.service = service;
    }

    public async Task<DashboardData> GetDashboardDataAsync(int genehmigerId)
    {

        var offene = await service.GetOffeneAntraegeAsync(genehmigerId);

        return new DashboardData
        {
            OffeneAntraege = offene,
            AnzahlOffen = offene.Count(),
            AnzahlUeberfaellig = offene.Count(a => (DateTime.UtcNow - a.GeaendertAm).TotalDays > 2)
        };
    }
}
