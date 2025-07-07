/*
Titel: PausenzeitWarningEventArgs
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Events/PausenzeitWarningEventArgs.cs
Beschreibung: EventArgs fuer Warnungen bei fehlenden Pausen
*/

namespace Arbeitszeiterfassung.BLL.Events;

/// <summary>
/// Eventargument fuer eine Warnung bei nicht eingehaltener Pausenzeit.
/// </summary>
public class PausenzeitWarningEventArgs : EventArgs
{
    public PausenzeitWarningEventArgs(TimeSpan fehlendePause)
    {
        FehlendePause = fehlendePause;
    }

    public TimeSpan FehlendePause { get; }
}
