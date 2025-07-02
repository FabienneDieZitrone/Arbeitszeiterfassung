/*
Titel: StandortService
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Services/StandortService.cs
Beschreibung: Service zum Laden von Standortdaten
*/
using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;
using Arbeitszeiterfassung.DAL.Repositories;
using Arbeitszeiterfassung.DAL.Interfaces;
using System.Linq;
using Arbeitszeiterfassung.BLL.Validators;

namespace Arbeitszeiterfassung.BLL.Services;

/// <summary>
/// Laedt und cached Standortinformationen aus der Datenbank.
/// </summary>
public class StandortService : IStandortService
{
    private readonly IStandortRepository standortRepo;
    private List<Standort> cached = new();

    public StandortService(IStandortRepository standortRepo)
    {
        this.standortRepo = standortRepo;
    }

    public async Task<List<Standort>> LoadStandorteAsync()
    {
        cached = (await standortRepo.GetAllAsync()).ToList();
        return cached;
    }

    public async Task<Standort?> FindByIPAsync(string ipAddress)
    {
        if (!cached.Any())
            await LoadStandorteAsync();

        return cached.FirstOrDefault(s => IPRangeValidator.IsInRangeStatic(ipAddress, s.IPRangeStart, s.IPRangeEnd));
    }
}
