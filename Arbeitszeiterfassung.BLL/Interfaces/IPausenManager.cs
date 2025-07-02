/*
Titel: IPausenManager
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Interfaces/IPausenManager.cs
Beschreibung: Schnittstelle fuer Pausenberechnungen
*/

using Arbeitszeiterfassung.DAL.Models;
using Arbeitszeiterfassung.BLL.Models;

namespace Arbeitszeiterfassung.BLL.Interfaces;

/// <summary>
/// Stellt Funktionen zur Berechnung und Validierung von Pausen bereit.
/// </summary>
public interface IPausenManager
{
    Task<TimeSpan> GetGesetzlichePauseAsync(TimeSpan arbeitszeit);
    Task<bool> ValidierePausenregelungAsync(Arbeitszeit arbeitszeit);
    Task<Pausenvorschlag> GetPausenvorschlagAsync(TimeSpan bisherige);
}
