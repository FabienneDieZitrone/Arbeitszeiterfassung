/*
Titel: DashboardData
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Models/DashboardData.cs
Beschreibung: Daten fuer das Genehmigungsdashboard
*/
using System.Collections.Generic;

using System.Linq;
namespace Arbeitszeiterfassung.BLL.Models;

/// <summary>
/// Datencontainer fuer das Genehmigungsdashboard.
/// </summary>
public class DashboardData
{
    public IEnumerable<object> OffeneAntraege { get; set; } = Enumerable.Empty<object>();
    public int AnzahlOffen { get; set; }
    public int AnzahlUeberfaellig { get; set; }
}
