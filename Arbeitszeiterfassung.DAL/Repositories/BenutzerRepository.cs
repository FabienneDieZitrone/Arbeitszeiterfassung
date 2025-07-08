/*
Titel: BenutzerRepository
Version: 1.1
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Repositories/BenutzerRepository.cs
Beschreibung: Repository fuer Benutzer.
*/

using Microsoft.EntityFrameworkCore;
using Arbeitszeiterfassung.DAL.Context;
using Arbeitszeiterfassung.DAL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.DAL.Repositories;

/// <summary>
/// Datenzugriff fuer Benutzer.
/// </summary>
public class BenutzerRepository : GenericRepository<Benutzer>, IBenutzerRepository
{
    public BenutzerRepository(ApplicationDbContext ctx) : base(ctx)
    {
    }

    public async Task<Benutzer?> GetBenutzerByUsernameAsync(string username) =>
        await dbSet.FirstOrDefaultAsync(b => b.Username == username);

    public async Task<Benutzer?> GetStandortleiterAsync(int standortId) =>
        await dbSet
            .Include(b => b.Rolle)
            .Include(b => b.BenutzerStandorte)
            .FirstOrDefaultAsync(b =>
                b.Rolle != null &&
                b.Rolle.Berechtigungsstufe == Berechtigungsstufe.Standortleiter &&
                b.BenutzerStandorte.Any(bs => bs.StandortId == standortId));

    public async Task<Benutzer?> GetBereichsleiterAsync() =>
        await dbSet
            .Include(b => b.Rolle)
            .FirstOrDefaultAsync(b =>
                b.Rolle != null &&
                b.Rolle.Berechtigungsstufe == Berechtigungsstufe.Bereichsleiter);

    public async Task<IEnumerable<int>> GetAllUserIdsAsync() =>
        await dbSet.Select(b => b.BenutzerId).ToListAsync();

    public async Task<IEnumerable<int>> GetUserIdsByStandorteAsync(IEnumerable<int> standortIds) =>
        await dbSet
            .Where(b => b.BenutzerStandorte.Any(bs => standortIds.Contains(bs.StandortId)))
            .Select(b => b.BenutzerId)
            .ToListAsync();

    public async Task<Benutzer?> GetBenutzerMitRolleAsync(int id) =>
        await dbSet.Include(b => b.Rolle).FirstOrDefaultAsync(b => b.BenutzerId == id);

    public async Task<Benutzer?> GetBenutzerMitDetailsAsync(int id) =>
        await dbSet
            .Include(b => b.Rolle)
            .Include(b => b.BenutzerStandorte)
            .FirstOrDefaultAsync(b => b.BenutzerId == id);
}
