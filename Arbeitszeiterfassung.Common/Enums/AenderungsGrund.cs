/*
Titel: AenderungsGrund.cs
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Enums/AenderungsGrund.cs
Beschreibung: Aufzählung der Gründe für Änderungen an Zeiteinträgen.
*/

namespace Arbeitszeiterfassung.Common.Enums;

/// <summary>
/// Gründe für Änderungsprotokolleinträge.
/// </summary>
public enum AenderungsGrund
{
    Korrektur,
    Nachtrag,
    System,
    Sonstiges
}
