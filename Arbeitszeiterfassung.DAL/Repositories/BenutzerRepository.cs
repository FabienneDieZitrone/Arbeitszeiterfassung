/*
Titel: BenutzerRepository
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Repositories/BenutzerRepository.cs
Beschreibung: Repository fuer Benutzer.
*/

using Microsoft.EntityFrameworkCore;
using Arbeitszeiterfassung.DAL.Context;
using Arbeitszeiterfassung.DAL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;

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
}
