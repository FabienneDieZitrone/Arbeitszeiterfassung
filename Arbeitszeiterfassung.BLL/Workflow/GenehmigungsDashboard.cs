/*
Titel: GenehmigungsDashboard
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Workflow/GenehmigungsDashboard.cs
Beschreibung: Aufbereitung der Dashboard-Daten
*/
using Arbeitszeiterfassung.BLL.Models;

namespace Arbeitszeiterfassung.BLL.Workflow;

/// <summary>
/// Erstellt Daten fuer das Genehmigungsdashboard.
/// </summary>
public class GenehmigungsDashboard
{
    public Task<DashboardData> GetDashboardDataAsync(int genehmigerId)
    {
        DashboardData data = new();
        return Task.FromResult(data);
    }
}
