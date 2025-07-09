/*
Titel: AutoGenehmigungsServiceTests
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Tests/AutoGenehmigungsServiceTests.cs
Beschreibung: Tests fuer den AutoGenehmigungsService
*/
using Arbeitszeiterfassung.BLL.Workflow;
using Arbeitszeiterfassung.DAL.Models;
using Xunit;

namespace Arbeitszeiterfassung.Tests;

/// <summary>
/// Testet die automatische Genehmigung.
/// </summary>
public class AutoGenehmigungsServiceTests
{
    [Fact]
    public async Task KannAutomatischGenehmigtWerdenAsync_ReturnsFalse()
    {
        var service = new AutoGenehmigungsService();
        var result = await service.KannAutomatischGenehmigtWerdenAsync(new Aenderungsprotokoll());
        Assert.False(result);
    }

    [Fact]
    public async Task KannAutomatischGenehmigtWerdenAsync_ReturnsTrue_ForSmallChange()
    {
        var service = new AutoGenehmigungsService();
        var protokoll = new Aenderungsprotokoll
        {
            Startzeit_Alt = DateTime.Today,
            Stoppzeit_Alt = DateTime.Today.AddHours(8),
            Startzeit_Neu = DateTime.Today.AddMinutes(5),
            Stoppzeit_Neu = DateTime.Today.AddHours(8).AddMinutes(5),
            GrundText = "Vergessen zu starten"
        };

        var result = await service.KannAutomatischGenehmigtWerdenAsync(protokoll);

        Assert.True(result);
    }
}
