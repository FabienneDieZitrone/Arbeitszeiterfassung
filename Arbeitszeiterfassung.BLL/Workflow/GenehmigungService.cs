/*
Titel: GenehmigungService
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Workflow/GenehmigungService.cs
Beschreibung: Kernlogik des Genehmigungsworkflows
*/
using System;
using System.Collections.Generic;
using System.Linq;
using Arbeitszeiterfassung.BLL.Services;
using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.BLL.Models;
using Arbeitszeiterfassung.DAL.Models;
using Arbeitszeiterfassung.DAL.Interfaces;
using Arbeitszeiterfassung.Common.Enums;

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

    public async Task<Aenderungsprotokoll> CreateAenderungsantragAsync(int arbeitszeitId, ArbeitszeitAenderung aenderung, string grund)
    {
        var original = await unitOfWork.Arbeitszeiten.GetByIdAsync(arbeitszeitId)
            ?? throw new ArgumentException(nameof(arbeitszeitId));

        var validation = await validator.ValidateAenderungAsync(original, aenderung);
        if (validation.Errors.Any())
            throw new InvalidOperationException(string.Join(";", validation.Errors));

        var protokoll = new Aenderungsprotokoll
        {
            EntityName = nameof(Arbeitszeit),
            EntityId = arbeitszeitId,
            OriginalID = arbeitszeitId,
            BenutzerID = original.BenutzerId,
            Datum = original.Start.Date,
            Startzeit_Alt = original.Start,
            Startzeit_Neu = aenderung.NeueStartzeit ?? original.Start,
            Stoppzeit_Alt = original.Stopp,
            Stoppzeit_Neu = aenderung.NeueStoppzeit ?? original.Stopp,
            Pausenzeit_Alt = original.Pause,
            Pausenzeit_Neu = aenderung.NeuePausenzeit ?? original.Pause,
            StandortID = aenderung.NeuerStandortId,
            GrundText = grund,
            Aktion = AenderungsAktion.Aktualisieren,
            Grund = AenderungsGrund.Nachtrag,
            Genehmigt = false,
            GeaendertVon = SessionManager.Instance.CurrentUser?.BenutzerId ?? 0
        };

        await unitOfWork.Aenderungsprotokolle.AddAsync(protokoll);
        await unitOfWork.SaveChangesAsync();

        var genehmiger = await unitOfWork.Benutzer.GetStandortleiterAsync(protokoll.StandortID ?? 0);
        if (genehmiger != null)
            await notificationService.SendeGenehmigungsanfrageAsync(protokoll, genehmiger);

        return protokoll;
    }

    public async Task<GenehmigungResult> GenehmigeAenderungAsync(int aenderungId, int genehmigerId, string? kommentar = null)
    {
        var antrag = await unitOfWork.Aenderungsprotokolle.GetByIdAsync(aenderungId)
            ?? throw new ArgumentException(nameof(aenderungId));

        if (!await authService.CanApproveChangesAsync(genehmigerId, antrag.BenutzerID))
            return new GenehmigungResult { Erfolg = false, Nachricht = "Keine Berechtigung" };

        var arbeitszeit = await unitOfWork.Arbeitszeiten.GetByIdAsync(antrag.OriginalID);
        if (arbeitszeit != null)
        {
            arbeitszeit.Start = antrag.Startzeit_Neu;
            arbeitszeit.Stopp = antrag.Stoppzeit_Neu;
            arbeitszeit.Pause = antrag.Pausenzeit_Neu;
            await unitOfWork.Arbeitszeiten.UpdateAsync(arbeitszeit);
        }

        antrag.Genehmigt = true;
        antrag.GenehmigtVon = genehmigerId;
        antrag.GenehmigtAm = DateTime.UtcNow;
        await unitOfWork.Aenderungsprotokolle.UpdateAsync(antrag);

        await notificationService.SendeGenehmigungsentscheidungAsync(antrag, true);
        return new GenehmigungResult { Erfolg = true };
    }

    public async Task<GenehmigungResult> LehneAenderungAbAsync(int aenderungId, int genehmigerId, string grund)
    {
        var antrag = await unitOfWork.Aenderungsprotokolle.GetByIdAsync(aenderungId)
            ?? throw new ArgumentException(nameof(aenderungId));
        if (!await authService.CanApproveChangesAsync(genehmigerId, antrag.BenutzerID))
            return new GenehmigungResult { Erfolg = false, Nachricht = "Keine Berechtigung" };

        antrag.Genehmigt = false;
        antrag.GenehmigtVon = genehmigerId;
        antrag.GenehmigtAm = DateTime.UtcNow;
        antrag.GrundText = grund;
        await unitOfWork.Aenderungsprotokolle.UpdateAsync(antrag);
        await notificationService.SendeGenehmigungsentscheidungAsync(antrag, false);
        return new GenehmigungResult { Erfolg = true };
    }

    public async Task<IEnumerable<Aenderungsprotokoll>> GetOffeneAntraegeAsync(int genehmigerId)
    {
        var antraege = await unitOfWork.Aenderungsprotokolle.GetUngenehmigteAenderungenAsync();
        return antraege.Where(a => !a.Genehmigt);
    }

    public async Task<IEnumerable<Aenderungsprotokoll>> GetAntraegeVonBenutzerAsync(int benutzerId)
    {
        return await unitOfWork.Aenderungsprotokolle.FindAsync(a => a.BenutzerID == benutzerId);
    }

    public async Task EskaliereUeberfaelligeAntraegeAsync()
    {
        var offene = await unitOfWork.Aenderungsprotokolle.GetUngenehmigteAenderungenAsync();
        var ueberfaellig = offene.Where(a => (DateTime.UtcNow - a.GeaendertAm).TotalDays > 2);
        foreach (var antrag in ueberfaellig)
        {
            var genehmiger = await unitOfWork.Benutzer.GetStandortleiterAsync(antrag.StandortID ?? 0);
            if (genehmiger != null)
                await notificationService.SendeEskalationAsync(antrag, genehmiger);
        }
    }
}
