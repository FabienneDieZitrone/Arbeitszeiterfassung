/*
Titel: AutoGenehmigungsService
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Workflow/AutoGenehmigungsService.cs
Beschreibung: Automatische Genehmigungen
*/
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Workflow;

/// <summary>
/// Logik fuer automatische Genehmigungen (vereinfacht).
/// </summary>
public class AutoGenehmigungsService
{
    public Task<bool> KannAutomatischGenehmigtWerdenAsync(Aenderungsprotokoll antrag)
    {
        return Task.FromResult(false);
    }
}
