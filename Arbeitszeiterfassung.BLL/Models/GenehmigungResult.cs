/*
Titel: GenehmigungResult
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Models/GenehmigungResult.cs
Beschreibung: Ergebnis des Genehmigungsprozesses
*/

namespace Arbeitszeiterfassung.BLL.Models;

/// <summary>
/// Ergebnis eines Genehmigungsvorgangs.
/// </summary>
public class GenehmigungResult
{
    public bool Erfolg { get; set; }
    public string? Nachricht { get; set; }
}
