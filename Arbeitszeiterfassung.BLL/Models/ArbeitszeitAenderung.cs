/*
Titel: ArbeitszeitAenderung
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Models/ArbeitszeitAenderung.cs
Beschreibung: Modell fuer beantragte Aenderungen
*/

namespace Arbeitszeiterfassung.BLL.Models;

/// <summary>
/// Repraesentiert beantragte Aenderungen einer Arbeitszeit.
/// </summary>
public class ArbeitszeitAenderung
{
    public DateTime? NeueStartzeit { get; set; }
    public DateTime? NeueStoppzeit { get; set; }
    public TimeSpan? NeuePausenzeit { get; set; }
    public int? NeuerStandortId { get; set; }

    public bool IstStartzeitGeaendert => NeueStartzeit.HasValue;
    public bool IstStoppzeitGeaendert => NeueStoppzeit.HasValue;
    public bool IstPausenzeitGeaendert => NeuePausenzeit.HasValue;
    public bool IstStandortGeaendert => NeuerStandortId.HasValue;
}
