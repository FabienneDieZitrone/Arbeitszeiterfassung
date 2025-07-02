/*
Titel: UeberstundenWarningEventArgs
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Events/UeberstundenWarningEventArgs.cs
Beschreibung: EventArgs fuer Ueberstundenwarnungen
*/

namespace Arbeitszeiterfassung.BLL.Events;

/// <summary>
/// Eventargument fuer eine Ueberstundenwarnung.
/// </summary>
public class UeberstundenWarningEventArgs : EventArgs
{
    public UeberstundenWarningEventArgs(decimal ueberstunden)
    {
        Ueberstunden = ueberstunden;
    }

    public decimal Ueberstunden { get; }
}
