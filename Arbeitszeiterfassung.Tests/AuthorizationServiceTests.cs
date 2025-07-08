/*
Titel: AuthorizationServiceTests
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Tests/AuthorizationServiceTests.cs
Beschreibung: Tests fuer den AuthorizationService
*/
using Arbeitszeiterfassung.BLL.Authorization;
using Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.Common.Enums;
using Arbeitszeiterfassung.DAL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;
using Arbeitszeiterfassung.DAL.UnitOfWork;
using FluentAssertions;
using Moq;
using Xunit;

namespace Arbeitszeiterfassung.Tests;

/// <summary>
/// Testet den AuthorizationService.
/// </summary>
public class AuthorizationServiceTests
{
    [Fact]
    public async Task HasPermissionAsync_ReturnsTrueForAdmin()
    {
        var benutzer = new Benutzer { BenutzerId = 1, Rolle = new Rolle { Berechtigungsstufe = Berechtigungsstufe.Admin } };
        var benRepo = new Mock<IBenutzerRepository>();
        benRepo.Setup(r => r.GetBenutzerMitRolleAsync(1)).ReturnsAsync(benutzer);
        var uow = new Mock<IUnitOfWork>();
        uow.Setup(u => u.Benutzer).Returns(benRepo.Object);
        var validator = new Mock<IDataAccessValidator>();
        var audit = new BerechtigungsAudit(new Mock<ISessionManager>().Object);
        var service = new AuthorizationService(uow.Object, validator.Object, audit);

        var result = await service.HasPermissionAsync(1, Permission.ManageSystem);

        result.Should().BeTrue();
    }
}
