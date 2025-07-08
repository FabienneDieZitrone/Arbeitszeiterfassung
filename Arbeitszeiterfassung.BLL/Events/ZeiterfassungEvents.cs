/*
Titel: ZeiterfassungEvents
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Events/ZeiterfassungEvents.cs
Beschreibung: Container fuer alle Zeiterfassungsevents
*/
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Events;

/// <summary>
/// Definiert die Events der Zeiterfassung.
/// </summary>
public class ZeiterfassungEvents
{
    public event EventHandler<ArbeitszeitStartedEventArgs>? ArbeitszeitGestartet;
    public event EventHandler<ArbeitszeitStoppedEventArgs>? ArbeitszeitGestoppt;
    public event EventHandler<UeberstundenWarningEventArgs>? UeberstundenWarnung;
    public event EventHandler<PausenzeitWarningEventArgs>? PausenzeitWarnung;

    internal void RaiseArbeitszeitGestartet(Arbeitszeit eintrag)
        => ArbeitszeitGestartet?.Invoke(this, new ArbeitszeitStartedEventArgs(eintrag));

    internal void RaiseArbeitszeitGestoppt(Arbeitszeit eintrag)
        => ArbeitszeitGestoppt?.Invoke(this, new ArbeitszeitStoppedEventArgs(eintrag));

    internal void RaiseUeberstundenWarnung(decimal stunden)
        => UeberstundenWarnung?.Invoke(this, new UeberstundenWarningEventArgs(stunden));

    internal void RaisePausenzeitWarnung(TimeSpan fehlendePause)
        => PausenzeitWarnung?.Invoke(this, new PausenzeitWarningEventArgs(fehlendePause));
}
