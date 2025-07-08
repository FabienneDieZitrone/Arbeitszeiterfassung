/*
Titel: GenehmigungsHierarchie
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Authorization/GenehmigungsHierarchie.cs
Beschreibung: Ermittelt zustaendige Genehmiger fuer Aenderungen
*/

using Arbeitszeiterfassung.DAL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;
using System.Linq;

namespace Arbeitszeiterfassung.BLL.Authorization;

/// <summary>
/// Liefert den zustaendigen Genehmiger fuer einen Mitarbeiter.
/// </summary>
public class GenehmigungsHierarchie
{
    private readonly IBenutzerRepository _benutzerRepository;

    public GenehmigungsHierarchie(IBenutzerRepository repo)
    {
        _benutzerRepository = repo;
    }

    public async Task<Benutzer?> GetGenehmiger(Benutzer mitarbeiter)
    {
        var hauptstandort = mitarbeiter.BenutzerStandorte
            .FirstOrDefault(bs => bs.IstHauptstandort);

        if (hauptstandort != null)
        {
            return await _benutzerRepository
                .GetStandortleiterAsync(hauptstandort.StandortId);
        }

        return await _benutzerRepository.GetBereichsleiterAsync();
    }
}
