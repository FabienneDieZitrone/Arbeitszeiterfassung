/*
Titel: IConflictResolver Interface
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Interfaces/IConflictResolver.cs
Beschreibung: Schnittstelle zur Konfliktloesung bei der Synchronisation.
*/

namespace Arbeitszeiterfassung.DAL.Interfaces;

/// <summary>
/// Definiert Methoden zur Konfliktaufloesung.
/// </summary>
public interface IConflictResolver
{
    Task<ConflictResolution> ResolveAsync<T>(T localEntity, T serverEntity);
    Task<bool> CanAutoResolveAsync(ConflictInfo conflict);
    ConflictStrategy GetStrategyForEntity(Type entityType);
}

/// <summary>
/// Ergebnis eines Konflikts.
/// </summary>
public class ConflictResolution
{
    public bool Resolved { get; init; }
    public string? Message { get; init; }
}

public class ConflictInfo
{
    public Type EntityType { get; init; } = typeof(object);
}

public enum ConflictStrategy
{
    ServerWins,
    ClientWins,
    LastWriteWins,
    Manual,
    Merge
}
