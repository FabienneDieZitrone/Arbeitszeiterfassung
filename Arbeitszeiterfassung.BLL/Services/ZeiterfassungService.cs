/*
Titel: ZeiterfassungService
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Services/ZeiterfassungService.cs
Beschreibung: Kernlogik fuer Start und Stopp der Arbeitszeit
*/

using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.BLL.Events;
using Arbeitszeiterfassung.BLL.Helpers;
using Arbeitszeiterfassung.BLL.Models;
using Arbeitszeiterfassung.DAL.Models;
using Arbeitszeiterfassung.DAL.UnitOfWork;
using System.Linq;

namespace Arbeitszeiterfassung.BLL.Services;

/// <summary>
/// Implementiert die Zeiterfassungslogik.
/// </summary>
public class ZeiterfassungService : IZeiterfassungService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IStandortService standortService;
    private readonly IArbeitszeitValidator validator;
    private readonly IArbeitszeitCalculator calculator;
    private readonly IPausenManager pausenManager;
    private readonly ISessionManager sessionManager;
    private readonly ZeiterfassungEvents events = new();

    public ZeiterfassungService(IUnitOfWork unitOfWork,
        IStandortService standortService,
        IArbeitszeitValidator validator,
        IArbeitszeitCalculator calculator,
        IPausenManager pausenManager,
        ISessionManager sessionManager)
    {
        this.unitOfWork = unitOfWork;
        this.standortService = standortService;
        this.validator = validator;
        this.calculator = calculator;
        this.pausenManager = pausenManager;
        this.sessionManager = sessionManager;
    }

    public event EventHandler<ArbeitszeitStartedEventArgs>? ArbeitszeitGestartet
    {
        add => events.ArbeitszeitGestartet += value;
        remove => events.ArbeitszeitGestartet -= value;
    }

    public event EventHandler<ArbeitszeitStoppedEventArgs>? ArbeitszeitGestoppt
    {
        add => events.ArbeitszeitGestoppt += value;
        remove => events.ArbeitszeitGestoppt -= value;
    }

    public async Task<Arbeitszeit> StartArbeitszeitAsync(int benutzerId)
    {
        var benutzer = await unitOfWork.Benutzer.GetByIdAsync(benutzerId);
        var ip = EnvironmentHelper.GetLocalIPAddress();
        var standort = await standortService.FindByIPAsync(ip);
        var valid = validator.ValidateStart(benutzer!, standort!);
        if (!valid.IsValid)
            throw new InvalidOperationException(string.Join(";", valid.Errors));

        var arbeitszeit = new Arbeitszeit
        {
            BenutzerId = benutzerId,
            Start = DateTime.Now,
            Stopp = DateTime.MinValue,
            Pause = TimeSpan.Zero,
            IstOfflineErfasst = false,
            IstSynchronisiert = false
        };

        await unitOfWork.Arbeitszeiten.AddAsync(arbeitszeit);
        await unitOfWork.SaveChangesAsync();
        events.RaiseArbeitszeitGestartet(arbeitszeit);
        return arbeitszeit;
    }

    public async Task<Arbeitszeit> StoppArbeitszeitAsync(int benutzerId)
    {
        var arbeitszeit = await GetAktuelleArbeitszeitAsync(benutzerId);
        if (arbeitszeit == null)
            throw new InvalidOperationException("Keine aktive Arbeitszeit vorhanden");

        arbeitszeit.Stopp = DateTime.Now;
        arbeitszeit.Pause = await pausenManager.GetGesetzlichePauseAsync(arbeitszeit.Stopp - arbeitszeit.Start);
        var validation = validator.ValidateStopp(arbeitszeit);
        if (!validation.IsValid)
            throw new InvalidOperationException(string.Join(";", validation.Errors));

        await unitOfWork.Arbeitszeiten.UpdateAsync(arbeitszeit);
        await unitOfWork.SaveChangesAsync();
        events.RaiseArbeitszeitGestoppt(arbeitszeit);
        return arbeitszeit;
    }

    public Task<Arbeitszeit?> GetAktuelleArbeitszeitAsync(int benutzerId)
        => unitOfWork.Arbeitszeiten.GetAktuelleArbeitszeitAsync(benutzerId);

    public async Task<bool> IstArbeitszeitAktivAsync(int benutzerId)
        => await GetAktuelleArbeitszeitAsync(benutzerId) != null;

    public async Task<TimeSpan> GetTagesarbeitszeitAsync(int benutzerId, DateTime datum)
    {
        var eintraege = await unitOfWork.Arbeitszeiten.FindAsync(a => a.BenutzerId == benutzerId && a.Start.Date == datum.Date && a.Stopp > DateTime.MinValue);
        return TimeSpan.FromHours(eintraege.Sum(a => (a.Stopp - a.Start - a.Pause).TotalHours));
    }

    public async Task<decimal> GetWochenarbeitszeitAsync(int benutzerId, DateTime woche)
    {
        var (start, ende) = GetWeekRange(woche);
        var eintraege = await unitOfWork.Arbeitszeiten.FindAsync(a => a.BenutzerId == benutzerId && a.Start.Date >= start && a.Start.Date <= ende && a.Stopp > DateTime.MinValue);
        return (decimal)eintraege.Sum(a => (a.Stopp - a.Start - a.Pause).TotalHours);
    }

    public async Task<ArbeitszeitStatus> GetStatusAsync(int benutzerId)
    {
        ArbeitszeitStatus status = new();
        status.IstAktiv = await IstArbeitszeitAktivAsync(benutzerId);
        if (status.IstAktiv)
        {
            var aktuell = await GetAktuelleArbeitszeitAsync(benutzerId);
            status.AktuellerStart = aktuell?.Start;
            status.BisherigeArbeitszeit = DateTime.Now - aktuell!.Start;
        }

        status.TagesIst = (decimal)(await GetTagesarbeitszeitAsync(benutzerId, DateTime.Today)).TotalHours;
        status.WochenIst = await GetWochenarbeitszeitAsync(benutzerId, DateTime.Today);
        return status;
    }

    private static (DateTime, DateTime) GetWeekRange(DateTime datum)
    {
        int diff = (7 + (datum.DayOfWeek - DayOfWeek.Monday)) % 7;
        DateTime start = datum.AddDays(-diff).Date;
        DateTime ende = start.AddDays(6);
        return (start, ende);
    }
}
