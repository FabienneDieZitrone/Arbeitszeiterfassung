/*
Titel: IGenehmigungService
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Interfaces/IGenehmigungService.cs
Beschreibung: Schnittstelle fuer den Genehmigungsworkflow
*/
using Arbeitszeiterfassung.BLL.Models;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Interfaces;

/// <summary>
/// Definiert die Funktionen des Genehmigungsservices.
/// </summary>
public interface IGenehmigungService
{
    Task<Aenderungsprotokoll> CreateAenderungsantragAsync(int arbeitszeitId, ArbeitszeitAenderung aenderung, string grund);
    Task<GenehmigungResult> GenehmigeAenderungAsync(int aenderungId, int genehmigerId, string? kommentar = null);
    Task<GenehmigungResult> LehneAenderungAbAsync(int aenderungId, int genehmigerId, string grund);
    Task<IEnumerable<Aenderungsprotokoll>> GetOffeneAntraegeAsync(int genehmigerId);
    Task<IEnumerable<Aenderungsprotokoll>> GetAntraegeVonBenutzerAsync(int benutzerId);
    Task EskaliereUeberfaelligeAntraegeAsync();
}
