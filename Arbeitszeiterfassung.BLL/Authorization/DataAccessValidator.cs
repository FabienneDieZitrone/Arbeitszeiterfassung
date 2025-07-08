/*
Titel: DataAccessValidator
Version: 1.1
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Authorization/DataAccessValidator.cs
Beschreibung: Prueft Zugriff auf Benutzerdaten anhand der Rolle
*/

using Arbeitszeiterfassung.Common.Enums;
using Arbeitszeiterfassung.DAL.Models;
using Arbeitszeiterfassung.BLL.Interfaces;
using System.Linq;

namespace Arbeitszeiterfassung.BLL.Authorization;

/// <summary>
/// Validiert Zugriffe auf Benutzerdaten.
/// </summary>
public class DataAccessValidator : IDataAccessValidator
{
    public Task<bool> CanAccessUserDataAsync(Benutzer accessor, Benutzer target)
    {
        if (accessor.BenutzerId == target.BenutzerId)
            return Task.FromResult(true);

        if (accessor.Rolle?.Berechtigungsstufe == Berechtigungsstufe.Admin)
            return Task.FromResult(true);
        if (accessor.Rolle?.Berechtigungsstufe == Berechtigungsstufe.Bereichsleiter)
            return Task.FromResult(true);
        if (accessor.Rolle?.Berechtigungsstufe == Berechtigungsstufe.Standortleiter)
            return HaveCommonStandortAsync(accessor, target);

        return Task.FromResult(false);
    }

    public Task<bool> HaveCommonStandortAsync(Benutzer accessor, Benutzer target)
    {
        var accessorIds = accessor.BenutzerStandorte.Select(bs => bs.StandortId).ToHashSet();
        return Task.FromResult(target.BenutzerStandorte.Any(bs => accessorIds.Contains(bs.StandortId)));
    }
}
