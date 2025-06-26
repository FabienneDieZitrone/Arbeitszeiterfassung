/*
Titel: AenderungsprotokollRepository
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Repositories/AenderungsprotokollRepository.cs
Beschreibung: Repository fuer Aenderungsprotokolle.
*/

using Microsoft.EntityFrameworkCore;
using Arbeitszeiterfassung.DAL.Context;
using Arbeitszeiterfassung.DAL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.DAL.Repositories;

/// <summary>
/// Datenzugriff fuer Aenderungsprotokolle.
/// </summary>
public class AenderungsprotokollRepository : GenericRepository<Aenderungsprotokoll>, IAenderungsprotokollRepository
{
    public AenderungsprotokollRepository(ApplicationDbContext ctx) : base(ctx)
    {
    }

    public async Task<IEnumerable<Aenderungsprotokoll>> GetUngenehmigteAenderungenAsync() =>
        await dbSet.Where(a => !a.Genehmigt).ToListAsync();
}
