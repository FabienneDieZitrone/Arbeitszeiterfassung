/*
Titel: AuthorizationService
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Authorization/AuthorizationService.cs
Beschreibung: Prueft Berechtigungen von Benutzern
*/

using Arbeitszeiterfassung.Common.Enums;
using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.DAL.UnitOfWork;
using Arbeitszeiterfassung.DAL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;
using System.Linq;

namespace Arbeitszeiterfassung.BLL.Authorization;

/// <summary>
/// Implementierung des AuthorizationService.
/// </summary>
public class AuthorizationService : IAuthorizationService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IDataAccessValidator dataAccessValidator;

    public AuthorizationService(IUnitOfWork uow, IDataAccessValidator validator)
    {
        unitOfWork = uow;
        dataAccessValidator = validator;
    }

    public async Task<bool> HasPermissionAsync(int benutzerId, Permission permission)
    {
        var user = await unitOfWork.Benutzer.GetByIdAsync(benutzerId);
        if (user == null || user.Rolle == null)
            return false;
        var perms = RolePermissionMapping.GetPermissions(user.Rolle.Berechtigungsstufe);
        return perms.HasFlag(permission);
    }

    public async Task<IEnumerable<Permission>> GetUserPermissionsAsync(int benutzerId)
    {
        var user = await unitOfWork.Benutzer.GetByIdAsync(benutzerId);
        if (user == null || user.Rolle == null)
            return Array.Empty<Permission>();

        var perms = RolePermissionMapping.GetPermissions(user.Rolle.Berechtigungsstufe);
        return Enum.GetValues<Permission>().Where(p => p != Permission.None && perms.HasFlag(p));
    }

    public async Task<bool> CanAccessDataAsync(int benutzerId, int targetUserId)
    {
        var accessor = await unitOfWork.Benutzer.GetByIdAsync(benutzerId);
        var target = await unitOfWork.Benutzer.GetByIdAsync(targetUserId);
        if (accessor == null || target == null)
            return false;

        return await dataAccessValidator.CanAccessUserDataAsync(accessor, target);
    }

    public async Task<bool> CanAccessStandortAsync(int benutzerId, int standortId)
    {
        var accessor = await unitOfWork.Benutzer.GetByIdAsync(benutzerId);
        if (accessor == null)
            return false;

        return accessor.BenutzerStandorte.Any(bs => bs.StandortId == standortId);
    }

    public async Task<bool> CanEditArbeitszeitAsync(int benutzerId, int arbeitszeitId)
    {
        if (await HasPermissionAsync(benutzerId, Permission.EditAllData))
            return true;

        var arbeitszeit = await unitOfWork.Arbeitszeiten.GetByIdAsync(arbeitszeitId);
        return arbeitszeit != null && arbeitszeit.BenutzerId == benutzerId;
    }

    public async Task<bool> CanApproveChangesAsync(int benutzerId, int targetUserId)
    {
        if (await HasPermissionAsync(benutzerId, Permission.ApproveAllChanges))
            return true;
        if (await HasPermissionAsync(benutzerId, Permission.ApproveStandortChanges))
        {
            var accessor = await unitOfWork.Benutzer.GetByIdAsync(benutzerId);
            var target = await unitOfWork.Benutzer.GetByIdAsync(targetUserId);
            if (accessor != null && target != null)
            {
                return await dataAccessValidator.HaveCommonStandortAsync(accessor, target);
            }
        }
        return false;
    }
}
