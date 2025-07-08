/*
Titel: RollenVergabeRegeln
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Authorization/RollenVergabeRegeln.cs
Beschreibung: Regeln fuer die Rollenvergabe
*/

using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.BLL.Authorization;

/// <summary>
/// Bewertet, ob eine Rolle vergeben werden darf.
/// </summary>
public class RollenVergabeRegeln
{
    public bool KannRolleVergeben(Berechtigungsstufe vergebenderRolle, Berechtigungsstufe zuVergebendeRolle)
    {
        return vergebenderRolle switch
        {
            Berechtigungsstufe.Admin => true,
            Berechtigungsstufe.Bereichsleiter => zuVergebendeRolle < Berechtigungsstufe.Admin,
            Berechtigungsstufe.Standortleiter => zuVergebendeRolle <= Berechtigungsstufe.Honorarkraft,
            _ => false
        };
    }
}
