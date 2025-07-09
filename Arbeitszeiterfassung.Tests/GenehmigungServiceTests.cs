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

    [Fact]
    public async Task GenehmigeAenderungAsync_ReturnsSuccess()
    {
        var antrag = new Aenderungsprotokoll { AenderungsprotokollId = 1, OriginalID = 1, BenutzerID = 2, Startzeit_Neu = DateTime.Today, Stoppzeit_Neu = DateTime.Today.AddHours(8) };
        var arbeitszeit = new Arbeitszeit { ArbeitszeitId = 1, BenutzerId = 2, Start = DateTime.Today, Stopp = DateTime.Today.AddHours(8), Pause = TimeSpan.Zero };

        var protokollRepo = new Mock<IAenderungsprotokollRepository>();
        protokollRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(antrag);
        protokollRepo.Setup(r => r.UpdateAsync(antrag)).Returns(Task.CompletedTask);

        var arbeitsRepo = new Mock<IArbeitszeitRepository>();
        arbeitsRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(arbeitszeit);
        arbeitsRepo.Setup(r => r.UpdateAsync(arbeitszeit)).Returns(Task.CompletedTask);

        var uow = new Mock<IUnitOfWork>();
        uow.Setup(u => u.Aenderungsprotokolle).Returns(protokollRepo.Object);
        uow.Setup(u => u.Arbeitszeiten).Returns(arbeitsRepo.Object);
        uow.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

        var auth = new Mock<IAuthorizationService>();
        auth.Setup(a => a.CanApproveChangesAsync(5, antrag.BenutzerID)).ReturnsAsync(true);

        var notif = new Mock<INotificationService>();
        var validator = new Mock<IAenderungsValidator>();
        validator.Setup(v => v.ValidateAenderungAsync(It.IsAny<Arbeitszeit>(), It.IsAny<ArbeitszeitAenderung>())).ReturnsAsync(new ValidationResult());

        var service = new GenehmigungService(uow.Object, auth.Object, notif.Object, validator.Object);

        var result = await service.GenehmigeAenderungAsync(1, 5);

        Assert.True(result.Erfolg);
        notif.Verify(n => n.SendeGenehmigungsentscheidungAsync(antrag, true), Times.Once);
    }

    [Fact]
    public async Task LehneAenderungAbAsync_ReturnsSuccess()
    {
        var antrag = new Aenderungsprotokoll { AenderungsprotokollId = 2, OriginalID = 2, BenutzerID = 3 };

        var protokollRepo = new Mock<IAenderungsprotokollRepository>();
        protokollRepo.Setup(r => r.GetByIdAsync(2)).ReturnsAsync(antrag);
        protokollRepo.Setup(r => r.UpdateAsync(antrag)).Returns(Task.CompletedTask);

        var uow = new Mock<IUnitOfWork>();
        uow.Setup(u => u.Aenderungsprotokolle).Returns(protokollRepo.Object);
        uow.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

        var auth = new Mock<IAuthorizationService>();
        auth.Setup(a => a.CanApproveChangesAsync(5, antrag.BenutzerID)).ReturnsAsync(true);

        var notif = new Mock<INotificationService>();
        var validator = new Mock<IAenderungsValidator>();

        var service = new GenehmigungService(uow.Object, auth.Object, notif.Object, validator.Object);

        var result = await service.LehneAenderungAbAsync(2, 5, "Nein");

        Assert.True(result.Erfolg);
        notif.Verify(n => n.SendeGenehmigungsentscheidungAsync(antrag, false), Times.Once);
    }
}
