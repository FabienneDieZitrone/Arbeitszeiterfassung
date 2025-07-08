/*
Titel: INotificationService
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Interfaces/INotificationService.cs
Beschreibung: Benachrichtigungslogik fuer Genehmigungen
*/
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Interfaces;

/// <summary>
/// Versendet Benachrichtigungen im Genehmigungsworkflow.
/// </summary>
public interface INotificationService
{
    Task SendeGenehmigungsanfrageAsync(Aenderungsprotokoll antrag, Benutzer genehmiger);
    Task SendeGenehmigungsentscheidungAsync(Aenderungsprotokoll antrag, bool genehmigt);
    Task SendeEskalationAsync(Aenderungsprotokoll antrag, Benutzer neuerGenehmiger);
    Task SendeErinnerungAsync(IEnumerable<Aenderungsprotokoll> offeneAntraege);
}
