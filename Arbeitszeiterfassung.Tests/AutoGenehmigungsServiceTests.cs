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
}
