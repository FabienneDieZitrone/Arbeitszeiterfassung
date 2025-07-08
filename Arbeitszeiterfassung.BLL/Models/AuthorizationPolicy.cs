/*
Titel: AuthorizationPolicy
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Models/AuthorizationPolicy.cs
Beschreibung: Modell fuer Berechtigungsrichtlinien
*/

using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.BLL.Models;

/// <summary>
/// Stellt eine Policy mit benoetigten Berechtigungen dar.
/// </summary>
public class AuthorizationPolicy
{
    public AuthorizationPolicy(Permission permissions)
    {
        Permissions = permissions;
    }

    public Permission Permissions { get; }
}
