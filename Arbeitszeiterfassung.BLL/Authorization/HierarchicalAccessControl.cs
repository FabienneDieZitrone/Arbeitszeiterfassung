/*
Titel: HierarchicalAccessControl
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Authorization/HierarchicalAccessControl.cs
Beschreibung: Liefert zugaengliche Benutzer-IDs fuer einen Benutzer
*/

using Arbeitszeiterfassung.Common.Enums;
using Arbeitszeiterfassung.DAL.Interfaces;

namespace Arbeitszeiterfassung.BLL.Authorization;

/// <summary>
/// Hilfsklasse fuer hierarchische Zugriffspruefung.
/// </summary>
public class HierarchicalAccessControl
{
    private readonly IBenutzerRepository benutzerRepository;

    public HierarchicalAccessControl(IBenutzerRepository repo)
    {
        benutzerRepository = repo;
    }

    public async Task<IEnumerable<int>> GetAccessibleUserIdsAsync(int benutzerId)
    {
        var benutzer = await benutzerRepository.GetByIdAsync(benutzerId);
        if (benutzer == null || benutzer.Rolle == null)
            return Array.Empty<int>();

        switch (benutzer.Rolle.Berechtigungsstufe)
        {
            case Berechtigungsstufe.Admin:
            case Berechtigungsstufe.Bereichsleiter:
                return (await benutzerRepository.GetAllAsync()).Select(b => b.BenutzerId);
            case Berechtigungsstufe.Standortleiter:
                var ids = benutzer.BenutzerStandorte.Select(bs => bs.StandortId);
                var users = await benutzerRepository.FindAsync(b => b.BenutzerStandorte.Any(bs => ids.Contains(bs.StandortId)));
                return users.Select(u => u.BenutzerId);
            default:
                return new[] { benutzerId };
        }
    }
}
