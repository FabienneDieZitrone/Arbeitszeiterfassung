/*
Titel: AuthorizationPolicyBuilder
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Authorization/AuthorizationPolicyBuilder.cs
Beschreibung: Erstellt Berechtigungsrichtlinien
*/

using Arbeitszeiterfassung.Common.Enums;
using Arbeitszeiterfassung.BLL.Models;

namespace Arbeitszeiterfassung.BLL.Authorization;

/// <summary>
/// Baut Policies anhand vordefinierter Namen.
/// </summary>
public class AuthorizationPolicyBuilder
{
    public AuthorizationPolicy BuildPolicy(string policyName)
    {
        return policyName switch
        {
            "ViewOwnData" => new AuthorizationPolicy(Permission.ViewOwnData),
            "EditOwnData" => new AuthorizationPolicy(Permission.EditOwnData),
            "ManageStandort" => new AuthorizationPolicy(
                Permission.ViewAllStandortData | Permission.EditAllStandortData),
            "ApproveChanges" => new AuthorizationPolicy(
                Permission.ApproveStandortChanges | Permission.ApproveAllChanges),
            "AdminOnly" => new AuthorizationPolicy(Permission.ManageSystem),
            _ => throw new ArgumentException($"Unknown policy: {policyName}")
        };
    }
}
