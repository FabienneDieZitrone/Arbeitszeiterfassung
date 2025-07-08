/*
Titel: AenderungsValidatorTests
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Tests/AenderungsValidatorTests.cs
Beschreibung: Tests fuer den AenderungsValidator
*/
using System;
using Arbeitszeiterfassung.BLL.Models;
using Arbeitszeiterfassung.BLL.Validators;
using Arbeitszeiterfassung.DAL.Models;
using FluentAssertions;
using Xunit;

namespace Arbeitszeiterfassung.Tests;

/// <summary>
/// Testet den AenderungsValidator.
/// </summary>
public class AenderungsValidatorTests
{
    [Fact]
    public async Task ValidateAenderungAsync_ReturnsError_WhenStoppVorStart()
    {
        var validator = new AenderungsValidator();
        var original = new Arbeitszeit { Start = DateTime.Today, Stopp = DateTime.Today.AddHours(8) };
        var aenderung = new ArbeitszeitAenderung
        {
            NeueStartzeit = DateTime.Today.AddHours(5),
            NeueStoppzeit = DateTime.Today.AddHours(4)
        };

        var result = await validator.ValidateAenderungAsync(original, aenderung);

        result.Errors.Should().Contain("Stoppzeit muss nach Startzeit liegen");
    }
}
