/*
Titel: SyncOperation Enum
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Enums/SyncOperation.cs
Beschreibung: Operationstypen für die Offline-Synchronisation.
*/

namespace Arbeitszeiterfassung.Common.Enums;

/// <summary>
/// Mögliche Operationen in der SyncQueue.
/// </summary>
public enum SyncOperation
{
    Insert,
    Update,
    Delete
}
