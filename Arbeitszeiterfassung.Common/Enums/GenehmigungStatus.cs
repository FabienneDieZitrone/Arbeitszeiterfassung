/*
Titel: GenehmigungStatus Enum
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Enums/GenehmigungStatus.cs
Beschreibung: Status fuer Genehmigungsworkflows
*/

namespace Arbeitszeiterfassung.Common.Enums;

/// <summary>
/// Moegliche Statuswerte im Genehmigungsworkflow.
/// </summary>
public enum GenehmigungStatus
{
    Ausstehend = 0,
    Genehmigt = 1,
    Abgelehnt = 2,
    Eskaliert = 3,
    Zurueckgezogen = 4,
    AutomatischGenehmigt = 5
}
