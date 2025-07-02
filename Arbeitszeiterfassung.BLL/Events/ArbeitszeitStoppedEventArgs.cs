/*
Titel: ArbeitszeitStoppedEventArgs
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Events/ArbeitszeitStoppedEventArgs.cs
Beschreibung: EventArgs fuer gestoppte Arbeitszeiten
*/

using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Events;

/// <summary>
/// Eventargument fuer das Ende einer Arbeitszeit.
/// </summary>
public class ArbeitszeitStoppedEventArgs : EventArgs
{
    public ArbeitszeitStoppedEventArgs(Arbeitszeit eintrag)
    {
        Eintrag = eintrag;
    }

    public Arbeitszeit Eintrag { get; }
}
