/*
Titel: IArbeitszeitCalculator
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Interfaces/IArbeitszeitCalculator.cs
Beschreibung: Schnittstelle fuer Berechnungen der Arbeitszeit
*/

using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Interfaces;

/// <summary>
/// Berechnet verschiedene Werte der Arbeitszeiterfassung.
/// </summary>
public interface IArbeitszeitCalculator
{
    TimeSpan BerechneBruttoArbeitszeit(DateTime start, DateTime stopp);
    TimeSpan BerechneNettoArbeitszeit(TimeSpan brutto, TimeSpan pause);
    TimeSpan BerechneAutomatischePause(TimeSpan arbeitszeit);
    decimal BerechneWochenarbeitszeit(IEnumerable<Arbeitszeit> wochenzeiten);
    decimal BerechneUeberstunden(decimal ist, decimal soll);
    ArbeitszeitStatistik BerechneMonatsstatistik(int benutzerId, int jahr, int monat);
}
