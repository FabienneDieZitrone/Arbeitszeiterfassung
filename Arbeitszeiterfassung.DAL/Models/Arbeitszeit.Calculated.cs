/*
Titel: Arbeitszeit Calculated Properties
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Models/Arbeitszeit.Calculated.cs
Beschreibung: Berechnete Eigenschaften fuer Arbeitszeiteintrag
*/

namespace Arbeitszeiterfassung.DAL.Models;

public partial class Arbeitszeit
{
    /// <summary>Gesamtzeit zwischen Start und Stopp.</summary>
    public TimeSpan Gesamtzeit => Stopp - Start;

    /// <summary>Arbeitszeit ohne Pause.</summary>
    public TimeSpan ArbeitszeitDauer => Gesamtzeit - Pause;
}
