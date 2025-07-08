/*
Titel: RequirePermissionAttribute
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Attributes/RequirePermissionAttribute.cs
Beschreibung: Attribut fuer Berechtigungspruefungen
*/

using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.BLL.Attributes;

/// <summary>
/// Attribute zur Deklaration benoetigter Berechtigungen.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class RequirePermissionAttribute : Attribute
{
    public Permission RequiredPermission { get; }

    public RequirePermissionAttribute(Permission permission)
    {
        RequiredPermission = permission;
    }
}
