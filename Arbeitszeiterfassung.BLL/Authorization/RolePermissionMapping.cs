/*
Titel: RolePermissionMapping
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Authorization/RolePermissionMapping.cs
Beschreibung: Zuordnung von Berechtigungsstufen zu Berechtigungen
*/

using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.BLL.Authorization;

/// <summary>
/// Liefert die Berechtigungen fuer jede Rolle.
/// </summary>
public static class RolePermissionMapping
{
    private static readonly Dictionary<Berechtigungsstufe, Permission> rolePermissions =
        new()
        {
            [Berechtigungsstufe.Mitarbeiter] =
                Permission.ViewOwnData |
                Permission.EditOwnData,

            [Berechtigungsstufe.Honorarkraft] =
                Permission.ViewOwnData |
                Permission.EditOwnData,

            [Berechtigungsstufe.Standortleiter] =
                Permission.ViewOwnData |
                Permission.EditOwnData |
                Permission.ViewAllStandortData |
                Permission.EditAllStandortData |
                Permission.ApproveStandortChanges |
                Permission.ViewReports |
                Permission.ExportData,

            [Berechtigungsstufe.Bereichsleiter] =
                Permission.ViewOwnData |
                Permission.EditOwnData |
                Permission.ViewAllData |
                Permission.EditAllData |
                Permission.ApproveAllChanges |
                Permission.ManageUsers |
                Permission.ManageStandorte |
                Permission.ViewReports |
                Permission.ExportData |
                Permission.ViewAuditLog,

            [Berechtigungsstufe.Admin] =
                (Permission)(-1)
        };

    /// <summary>
    /// Gibt die Berechtigungen fuer die angegebene Stufe zurueck.
    /// </summary>
    public static Permission GetPermissions(Berechtigungsstufe stufe)
    {
        if (rolePermissions.TryGetValue(stufe, out var perm))
            return perm;
        return Permission.None;
    }
}
