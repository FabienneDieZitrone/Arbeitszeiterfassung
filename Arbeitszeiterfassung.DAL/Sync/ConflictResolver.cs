/*
Titel: ConflictResolver
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Sync/ConflictResolver.cs
Beschreibung: Einfache Konfliktloesung fuer die Synchronisation.
*/
using Arbeitszeiterfassung.DAL.Interfaces;

namespace Arbeitszeiterfassung.DAL.Sync;

/// <summary>
/// Basisklasse zur Konfliktaufloesung.
/// </summary>
public class ConflictResolver : IConflictResolver
{
    public Task<ConflictResolution> ResolveAsync<T>(T localEntity, T serverEntity)
    {
        return Task.FromResult(new ConflictResolution { Resolved = true });
    }

    public Task<bool> CanAutoResolveAsync(ConflictInfo conflict)
    {
        return Task.FromResult(true);
    }

    public ConflictStrategy GetStrategyForEntity(Type entityType) => ConflictStrategy.ServerWins;
}
