/*
Titel: IZeiterfassungService
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Interfaces/IZeiterfassungService.cs
Beschreibung: Schnittstelle fuer die Zeiterfassungslogik
*/

using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Interfaces;

/// <summary>
/// Definiert Methoden zur Steuerung der Zeiterfassung eines Benutzers.
/// </summary>
public interface IZeiterfassungService
{
    Task<Arbeitszeit> StartArbeitszeitAsync(int benutzerId);
    Task<Arbeitszeit> StoppArbeitszeitAsync(int benutzerId);
    Task<Arbeitszeit?> GetAktuelleArbeitszeitAsync(int benutzerId);
    Task<bool> IstArbeitszeitAktivAsync(int benutzerId);
    Task<TimeSpan> GetTagesarbeitszeitAsync(int benutzerId, DateTime datum);
    Task<decimal> GetWochenarbeitszeitAsync(int benutzerId, DateTime woche);
    Task<ArbeitszeitStatus> GetStatusAsync(int benutzerId);
}
