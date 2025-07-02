/*
Titel: AuthenticationService
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Services/AuthenticationService.cs
Beschreibung: Implementierung der Benutzerauthentifizierung
*/
using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.DAL.Interfaces;
using Arbeitszeiterfassung.BLL.Validators;
using Arbeitszeiterfassung.BLL.Helpers;
using Arbeitszeiterfassung.DAL.Models;
using System.Linq;
using Arbeitszeiterfassung.DAL.UnitOfWork;

namespace Arbeitszeiterfassung.BLL.Services;

/// <summary>
/// Service zur Authentifizierung auf Basis des Windows-Benutzers und der IP.
/// </summary>
public class AuthenticationService : IAuthenticationService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IStandortService standortService;
    private readonly IPRangeValidator ipValidator;

    public AuthenticationService(IUnitOfWork unitOfWork, IStandortService standortService)
    {
        this.unitOfWork = unitOfWork;
        this.standortService = standortService;
        ipValidator = new IPRangeValidator();
    }

    public async Task<Benutzer> AuthenticateAsync()
    {
        string username = EnvironmentHelper.GetWindowsUsername();
        string ip = EnvironmentHelper.GetLocalIPAddress();

        if (!await ValidateIPRangeAsync(ip))
            throw new InvalidOperationException("Sie befinden sich nicht im Firmennetzwerk.");

        Standort? standort = await GetStandortByIPAsync(ip);
        Benutzer benutzer = await CreateOrUpdateBenutzerAsync(username);

        if (standort != null)
        {
            benutzer.BenutzerStandorte.Add(new BenutzerStandort { BenutzerId = benutzer.BenutzerId, StandortId = standort.StandortId });
            await unitOfWork.SaveChangesAsync();
        }

        return benutzer;
    }

    public async Task<bool> ValidateIPRangeAsync(string ipAddress)
    {
        Standort? standort = await GetStandortByIPAsync(ipAddress);
        if (standort == null)
            return false;
        return ipValidator.IsInRange(ipAddress, standort.IPRangeStart, standort.IPRangeEnd);
    }

    public async Task<Standort?> GetStandortByIPAsync(string ipAddress)
    {
        return await standortService.FindByIPAsync(ipAddress);
    }

    public async Task<Benutzer> CreateOrUpdateBenutzerAsync(string username)
    {
        var repo = unitOfWork.Benutzer;
        Benutzer? existing = (await repo.FindAsync(b => b.Username == username)).FirstOrDefault();
        if (existing != null)
            return existing;

        Benutzer neu = new() { Username = username, RolleId = 1 };
        await repo.AddAsync(neu);
        await unitOfWork.SaveChangesAsync();
        return neu;
    }
}
