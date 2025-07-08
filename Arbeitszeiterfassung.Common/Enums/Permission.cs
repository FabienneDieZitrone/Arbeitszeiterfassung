/*
Titel: Permission Enum
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Enums/Permission.cs
Beschreibung: Berechtigungen fuer rollenbasierten Zugriff
*/

namespace Arbeitszeiterfassung.Common.Enums;

/// <summary>
/// Definiert alle moeglichen Berechtigungen.
/// </summary>
[Flags]
public enum Permission
{
    None = 0,

    // Basis-Berechtigungen
    ViewOwnData = 1 << 0,
    EditOwnData = 1 << 1,

    // Erweiterte Berechtigungen
    ViewAllStandortData = 1 << 2,
    ViewAllData = 1 << 3,
    EditAllStandortData = 1 << 4,
    EditAllData = 1 << 5,

    // Administrative Berechtigungen
    ManageUsers = 1 << 6,
    ManageStandorte = 1 << 7,
    ManageRoles = 1 << 8,
    ManageSystem = 1 << 9,

    // Genehmigungs-Berechtigungen
    ApproveStandortChanges = 1 << 10,
    ApproveAllChanges = 1 << 11,

    // Spezial-Berechtigungen
    ViewReports = 1 << 12,
    ExportData = 1 << 13,
    ViewAuditLog = 1 << 14,
    DeleteData = 1 << 15
}
