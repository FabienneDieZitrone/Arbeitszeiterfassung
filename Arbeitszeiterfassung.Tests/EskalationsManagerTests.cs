/*
Titel: EskalationsManagerTests
Version: 1.0
Letzte Aktualisierung: 09.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Tests/EskalationsManagerTests.cs
Beschreibung: Tests fuer den EskalationsManager
*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.BLL.Workflow;
using Arbeitszeiterfassung.DAL.Models;
using Moq;
using Xunit;

namespace Arbeitszeiterfassung.Tests;

/// <summary>
/// Testet den EskalationsManager.
/// </summary>
public class EskalationsManagerTests
{
    [Fact]
    public async Task PruefeUndEskaliereAsync_SendetEskalation()
    {
        var alterAntrag = new Aenderungsprotokoll
        {
            AenderungsprotokollId = 1,
            GeaendertAm = DateTime.UtcNow.AddDays(-6)
        };

        var service = new Mock<IGenehmigungService>();
        service.Setup(s => s.GetOffeneAntraegeAsync(0)).ReturnsAsync(new List<Aenderungsprotokoll> { alterAntrag });

        var notification = new Mock<INotificationService>();
        var manager = new EskalationsManager(service.Object, notification.Object);

        await manager.PruefeUndEskaliereAsync();

        notification.Verify(n => n.SendeEskalationAsync(alterAntrag, It.IsAny<Benutzer>()), Times.Once);
    }
}
