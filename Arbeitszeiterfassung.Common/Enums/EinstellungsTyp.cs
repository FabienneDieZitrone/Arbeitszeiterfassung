/*
Titel: EinstellungsTyp Enum
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Enums/EinstellungsTyp.cs
Beschreibung: Datentyp fuer Systemeinstellungen
*/

namespace Arbeitszeiterfassung.Common.Enums;

/// <summary>
/// Typ der gespeicherten Systemeinstellung.
/// </summary>
public enum EinstellungsTyp
{
    String,
    Number,
    Boolean,
    Json
}
