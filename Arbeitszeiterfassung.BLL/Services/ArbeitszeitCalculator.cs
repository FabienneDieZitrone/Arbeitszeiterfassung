/*
Titel: ArbeitszeitCalculator
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Services/ArbeitszeitCalculator.cs
Beschreibung: Berechnet Arbeitszeiten und Statistiken
*/

using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.BLL.Models;
using System.Linq;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Services;

/// <summary>
/// Implementierung der Arbeitszeitberechnungen.
/// </summary>
public class ArbeitszeitCalculator : IArbeitszeitCalculator
{
    public TimeSpan BerechneBruttoArbeitszeit(DateTime start, DateTime stopp)
        => stopp - start;

    public TimeSpan BerechneNettoArbeitszeit(TimeSpan brutto, TimeSpan pause)
        => brutto - pause;

    public TimeSpan BerechneAutomatischePause(TimeSpan arbeitszeit)
        => arbeitszeit.TotalHours switch
        {
            < 6 => TimeSpan.Zero,
            >= 6 and <= 9 => TimeSpan.FromMinutes(30),
            > 9 => TimeSpan.FromMinutes(45),
            _ => TimeSpan.Zero
        };

    public decimal BerechneWochenarbeitszeit(IEnumerable<Arbeitszeit> wochenzeiten)
        => (decimal)wochenzeiten.Sum(z => (z.Stopp - z.Start - z.Pause).TotalHours);

    public decimal BerechneUeberstunden(decimal ist, decimal soll)
        => ist - soll;

    public ArbeitszeitStatistik BerechneMonatsstatistik(int benutzerId, int jahr, int monat)
    {
        return new ArbeitszeitStatistik
        {
            SollStunden = 0,
            IstStunden = 0,
            Ueberstunden = 0
        };
    }
}
