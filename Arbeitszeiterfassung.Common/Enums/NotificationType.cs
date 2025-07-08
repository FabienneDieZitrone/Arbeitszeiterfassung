/*
Titel: NotificationType Enum
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Enums/NotificationType.cs
Beschreibung: Typen fuer Benachrichtigungen
*/

namespace Arbeitszeiterfassung.Common.Enums;

/// <summary>
/// Definiert die Arten von Benachrichtigungen im Genehmigungsworkflow.
/// </summary>
public enum NotificationType
{
    Genehmigungsanfrage,
    Genehmigungsentscheidung,
    Eskalation,
    Erinnerung
}
