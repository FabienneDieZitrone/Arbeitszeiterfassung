/*
Titel: PausenManager
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Services/PausenManager.cs
Beschreibung: Berechnet Pausen nach gesetzlichen Vorgaben
*/

using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.BLL.Models;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Services;

/// <summary>
/// Implementiert die Berechnung gesetzlicher Pausen.
/// </summary>
public class PausenManager : IPausenManager
{
    public Task<TimeSpan> GetGesetzlichePauseAsync(TimeSpan arbeitszeit)
    {
        TimeSpan pause = arbeitszeit.TotalHours switch
        {
            < 6 => TimeSpan.Zero,
            >= 6 and <= 9 => TimeSpan.FromMinutes(30),
            > 9 => TimeSpan.FromMinutes(45),
            _ => TimeSpan.Zero
        };
        return Task.FromResult(pause);
    }

    public async Task<bool> ValidierePausenregelungAsync(Arbeitszeit arbeitszeit)
    {
        TimeSpan erforderlich = await GetGesetzlichePauseAsync(arbeitszeit.Stopp - arbeitszeit.Start);
        return arbeitszeit.Pause >= erforderlich;
    }

    public async Task<Pausenvorschlag> GetPausenvorschlagAsync(TimeSpan bisherige)
    {
        TimeSpan erforderlich = await GetGesetzlichePauseAsync(bisherige);
        return new Pausenvorschlag
        {
            EmpfohlenePause = erforderlich,
            Hinweis = "Gesetzliche Mindestpause"
        };
    }
}
