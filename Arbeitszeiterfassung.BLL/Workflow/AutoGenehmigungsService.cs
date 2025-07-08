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
        var alteDauer = antrag.Stoppzeit_Alt - antrag.Startzeit_Alt;
        var neueDauer = antrag.Stoppzeit_Neu - antrag.Startzeit_Neu;
        var differenz = Math.Abs((neueDauer - alteDauer).TotalMinutes);

        if (differenz <= 15 && !string.IsNullOrWhiteSpace(antrag.GrundText))
        {
            string[] erlaubte =
            {
                "Vergessen zu starten",
                "Vergessen zu stoppen",
                "Systemfehler"
            };
            return Task.FromResult(erlaubte.Contains(antrag.GrundText));
        }

        return Task.FromResult(false);
    }
}
