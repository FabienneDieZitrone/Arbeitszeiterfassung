/*
Titel: GenehmigungsentscheidungService
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Workflow/GenehmigungsentscheidungService.cs
Beschreibung: Trifft Genehmigungsentscheidungen
*/

using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.BLL.Models;

namespace Arbeitszeiterfassung.BLL.Workflow;

/// <summary>
/// Trifft Entscheidungen zur Genehmigung von Antraegen.
/// </summary>
public class GenehmigungsentscheidungService
{
    private readonly IGenehmigungService service;

    public GenehmigungsentscheidungService(IGenehmigungService service)
    {
        this.service = service;
    }

    public Task<GenehmigungResult> GenehmigeAsync(int aenderungId, int genehmigerId, string kommentar)
        => service.GenehmigeAenderungAsync(aenderungId, genehmigerId, kommentar);

    public Task<GenehmigungResult> LehneAbAsync(int aenderungId, int genehmigerId, string grund)
        => service.LehneAenderungAbAsync(aenderungId, genehmigerId, grund);
}
