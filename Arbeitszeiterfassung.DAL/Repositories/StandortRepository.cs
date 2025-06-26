/*
Titel: StandortRepository
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Repositories/StandortRepository.cs
Beschreibung: Repository fuer Standorte.
*/

using Microsoft.EntityFrameworkCore;
using Arbeitszeiterfassung.DAL.Context;
using Arbeitszeiterfassung.DAL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.DAL.Repositories;

/// <summary>
/// Datenzugriff fuer Standorte.
/// </summary>
public class StandortRepository : GenericRepository<Standort>, IStandortRepository
{
    public StandortRepository(ApplicationDbContext ctx) : base(ctx)
    {
    }

    public async Task<Standort?> GetByBezeichnungAsync(string name) =>
        await dbSet.FirstOrDefaultAsync(s => s.Bezeichnung == name);
}
