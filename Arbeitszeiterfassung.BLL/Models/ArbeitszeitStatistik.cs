/*
Titel: ArbeitszeitStatistik
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Models/ArbeitszeitStatistik.cs
Beschreibung: Zusammenfassung der Arbeitszeiten eines Monats
*/

namespace Arbeitszeiterfassung.BLL.Models;

/// <summary>
/// Statistikdaten fuer einen Monat.
/// </summary>
public class ArbeitszeitStatistik
{
    public decimal SollStunden { get; set; }
    public decimal IstStunden { get; set; }
    public decimal Ueberstunden { get; set; }
}
