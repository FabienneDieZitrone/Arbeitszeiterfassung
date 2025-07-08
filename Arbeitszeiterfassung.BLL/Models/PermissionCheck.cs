/*
Titel: PermissionCheck
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Models/PermissionCheck.cs
Beschreibung: Ergebnis einer Berechtigungspruefung
*/

using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.BLL.Models;

/// <summary>
/// Speichert das Resultat einer Berechtigungspruefung.
/// </summary>
public class PermissionCheck
{
    public Permission Permission { get; set; }
    public bool Granted { get; set; }
}
