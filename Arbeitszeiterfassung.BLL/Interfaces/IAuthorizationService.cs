/*
Titel: IAuthorizationService
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Interfaces/IAuthorizationService.cs
Beschreibung: Schnittstelle fuer Berechtigungspruefungen
*/

using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.BLL.Interfaces;

/// <summary>
/// Schnittstelle fuer rollenbasierte Zugriffspruefung.
/// </summary>
public interface IAuthorizationService
{
    Task<bool> HasPermissionAsync(int benutzerId, Permission permission);
    Task<bool> CanAccessDataAsync(int benutzerId, int targetUserId);
    Task<bool> CanAccessStandortAsync(int benutzerId, int standortId);
    Task<bool> CanEditArbeitszeitAsync(int benutzerId, int arbeitszeitId);
    Task<bool> CanApproveChangesAsync(int benutzerId, int targetUserId);
    Task<IEnumerable<Permission>> GetUserPermissionsAsync(int benutzerId);
}
