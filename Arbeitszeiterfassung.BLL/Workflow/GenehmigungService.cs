/*
Titel: GenehmigungService
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Workflow/GenehmigungService.cs
Beschreibung: Kernlogik des Genehmigungsworkflows
*/
using System.Collections.Generic;
using System.Linq;
using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.BLL.Models;
using Arbeitszeiterfassung.DAL.Models;
using Arbeitszeiterfassung.DAL.Interfaces;

namespace Arbeitszeiterfassung.BLL.Workflow;

/// <summary>
/// Implementierung des Genehmigungsservices (vereinfacht).
/// </summary>
public class GenehmigungService : IGenehmigungService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IAuthorizationService authService;
    private readonly INotificationService notificationService;
    private readonly IAenderungsValidator validator;

    public GenehmigungService(
        IUnitOfWork unitOfWork,
        IAuthorizationService authService,
        INotificationService notificationService,
        IAenderungsValidator validator)
    {
        this.unitOfWork = unitOfWork;
        this.authService = authService;
        this.notificationService = notificationService;
        this.validator = validator;
    }

    public Task<Aenderungsprotokoll> CreateAenderungsantragAsync(int arbeitszeitId, ArbeitszeitAenderung aenderung, string grund)
    {
        // Platzhalterimplementierung
        return Task.FromResult(new Aenderungsprotokoll { AenderungsprotokollId = 0 });
    }

    public Task<GenehmigungResult> GenehmigeAenderungAsync(int aenderungId, int genehmigerId, string? kommentar = null)
    {
        return Task.FromResult(new GenehmigungResult { Erfolg = true });
    }

    public Task<GenehmigungResult> LehneAenderungAbAsync(int aenderungId, int genehmigerId, string grund)
    {
        return Task.FromResult(new GenehmigungResult { Erfolg = false });
    }

    public Task<IEnumerable<Aenderungsprotokoll>> GetOffeneAntraegeAsync(int genehmigerId)
    {
        return Task.FromResult(Enumerable.Empty<Aenderungsprotokoll>());
    }

    public Task<IEnumerable<Aenderungsprotokoll>> GetAntraegeVonBenutzerAsync(int benutzerId)
    {
        return Task.FromResult(Enumerable.Empty<Aenderungsprotokoll>());
    }

    public Task EskaliereUeberfaelligeAntraegeAsync()
    {
        return Task.CompletedTask;
    }
}
