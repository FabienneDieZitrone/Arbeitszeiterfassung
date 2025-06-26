/*
Titel: ArbeitszeitRepository
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Repositories/ArbeitszeitRepository.cs
Beschreibung: Repository fuer Arbeitszeiten.
*/

using Microsoft.EntityFrameworkCore;
using Arbeitszeiterfassung.DAL.Context;
using Arbeitszeiterfassung.DAL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.DAL.Repositories;

/// <summary>
/// Datenzugriff fuer Arbeitszeitentitaeten.
/// </summary>
public class ArbeitszeitRepository : GenericRepository<Arbeitszeit>, IArbeitszeitRepository
{
    public ArbeitszeitRepository(ApplicationDbContext ctx) : base(ctx)
    {
    }

    public async Task<Arbeitszeit?> GetAktuelleArbeitszeitAsync(int benutzerId) =>
        await dbSet.OrderByDescending(a => a.Start)
                    .FirstOrDefaultAsync(a => a.BenutzerId == benutzerId && a.Ende == null);
}
