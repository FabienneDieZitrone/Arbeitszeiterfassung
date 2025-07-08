/*
Titel: GenehmigungServiceTests
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Tests/GenehmigungServiceTests.cs
Beschreibung: Tests fuer den GenehmigungService
*/
using System;
using System.Threading.Tasks;
using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.BLL.Models;
using Arbeitszeiterfassung.BLL.Services;
using Arbeitszeiterfassung.BLL.Workflow;
using Arbeitszeiterfassung.BLL.Validators;
using Arbeitszeiterfassung.Common.Enums;
using Arbeitszeiterfassung.DAL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;
using Moq;
using Xunit;

namespace Arbeitszeiterfassung.Tests;

/// <summary>
/// Testet den GenehmigungService.
/// </summary>
public class GenehmigungServiceTests
{
    [Fact]
    public async Task CreateAenderungsantragAsync_ReturnsProtokoll()
    {
        var arbeitszeit = new Arbeitszeit
        {
            ArbeitszeitId = 1,
            BenutzerId = 2,
            Start = DateTime.Today,
            Stopp = DateTime.Today.AddHours(8),
            Pause = TimeSpan.Zero
        };

        var arbeitsRepo = new Mock<IArbeitszeitRepository>();
        arbeitsRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(arbeitszeit);

        var protokollRepo = new Mock<IAenderungsprotokollRepository>();
        protokollRepo.Setup(r => r.AddAsync(It.IsAny<Aenderungsprotokoll>()))
                     .ReturnsAsync((Aenderungsprotokoll p) => p);

        var uow = new Mock<IUnitOfWork>();
        uow.Setup(u => u.Arbeitszeiten).Returns(arbeitsRepo.Object);
        uow.Setup(u => u.Aenderungsprotokolle).Returns(protokollRepo.Object);
        uow.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);
        var benRepo = new Mock<IBenutzerRepository>();
        uow.Setup(u => u.Benutzer).Returns(benRepo.Object);

        var auth = new Mock<IAuthorizationService>();
        var notif = new Mock<INotificationService>();
        var validator = new AenderungsValidator();
        var service = new GenehmigungService(uow.Object, auth.Object, notif.Object, validator);
        SessionManager.Instance.StartSession(new Benutzer { BenutzerId = 99 });

        var result = await service.CreateAenderungsantragAsync(1, new ArbeitszeitAenderung { NeueStartzeit = DateTime.Today.AddHours(1) }, "Test");

        Assert.Equal(arbeitszeit.ArbeitszeitId, result.OriginalID);
    }
}
