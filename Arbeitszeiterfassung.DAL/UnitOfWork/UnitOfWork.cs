/*
Titel: UnitOfWork
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/UnitOfWork/UnitOfWork.cs
Beschreibung: Implementierung des Unit-of-Work Patterns.
*/

using Arbeitszeiterfassung.DAL.Context;
using Arbeitszeiterfassung.DAL.Interfaces;
using Arbeitszeiterfassung.DAL.Repositories;

namespace Arbeitszeiterfassung.DAL.UnitOfWork;

/// <summary>
/// Koordiniert die Repositories und stellt Transaktionen bereit.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;

    public UnitOfWork(ApplicationDbContext ctx)
    {
        context = ctx;
        Benutzer = new BenutzerRepository(ctx);
        Arbeitszeiten = new ArbeitszeitRepository(ctx);
        Standorte = new StandortRepository(ctx);
        Aenderungsprotokolle = new AenderungsprotokollRepository(ctx);
    }

    public IBenutzerRepository Benutzer { get; }
    public IArbeitszeitRepository Arbeitszeiten { get; }
    public IStandortRepository Standorte { get; }
    public IAenderungsprotokollRepository Aenderungsprotokolle { get; }

    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();

    public ValueTask DisposeAsync()
    {
        return context.DisposeAsync();
    }
}
