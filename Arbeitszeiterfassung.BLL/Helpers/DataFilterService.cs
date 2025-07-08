/*
Titel: DataFilterService
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Helpers/DataFilterService.cs
Beschreibung: Filtert Daten entsprechend der Benutzerberechtigungen
*/

using Arbeitszeiterfassung.Common.Enums;
using Arbeitszeiterfassung.DAL.Models;
using System.Linq;

namespace Arbeitszeiterfassung.BLL.Helpers;

/// <summary>
/// Bietet Filteroperationen fuer datenbankabfragen basierend auf Rollen.
/// </summary>
public class DataFilterService
{
    public IQueryable<Arbeitszeit> FilterArbeitszeitenForUser(
        IQueryable<Arbeitszeit> query,
        Benutzer user)
    {
        return user.Rolle?.Berechtigungsstufe switch
        {
            Berechtigungsstufe.Admin or Berechtigungsstufe.Bereichsleiter => query,
            Berechtigungsstufe.Standortleiter => query.Where(a =>
                a.Benutzer != null &&
                a.Benutzer.BenutzerStandorte.Any(bs => user.BenutzerStandorte.Any(ubs => ubs.StandortId == bs.StandortId))),
            _ => query.Where(a => a.BenutzerId == user.BenutzerId)
        };
    }
}
