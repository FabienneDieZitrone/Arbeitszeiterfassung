/*
Titel: SyncStatus Enum
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Enums/SyncStatus.cs
Beschreibung: Statuswerte für Einträge in der SyncQueue.
*/

namespace Arbeitszeiterfassung.Common.Enums;

/// <summary>
/// Status eines Synchronisationseintrags.
/// </summary>
public enum SyncStatus
{
    Neu,
    InBearbeitung,
    Erfolgreich,
    Fehler
}
