/*
Titel: ArbeitszeitStartedEventArgs
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Events/ArbeitszeitStartedEventArgs.cs
Beschreibung: EventArgs fuer gestartete Arbeitszeiten
*/

using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Events;

/// <summary>
/// Eventargument fuer den Start einer Arbeitszeit.
/// </summary>
public class ArbeitszeitStartedEventArgs : EventArgs
{
    public ArbeitszeitStartedEventArgs(Arbeitszeit eintrag)
    {
        Eintrag = eintrag;
    }

    public Arbeitszeit Eintrag { get; }
}
