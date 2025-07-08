/*
Titel: RolePermissionMappingTests
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Tests/RolePermissionMappingTests.cs
Beschreibung: Unit Tests fuer die Zuordnung von Rollen zu Berechtigungen
*/
using Arbeitszeiterfassung.Common.Enums;
using Arbeitszeiterfassung.BLL.Authorization;
using FluentAssertions;
using Xunit;

namespace Arbeitszeiterfassung.Tests;

/// <summary>
/// Testet die RolePermissionMapping-Klasse.
/// </summary>
public class RolePermissionMappingTests
{
    [Theory]
    [InlineData(Berechtigungsstufe.Mitarbeiter, Permission.ViewOwnData | Permission.EditOwnData)]
    [InlineData(Berechtigungsstufe.Honorarkraft, Permission.ViewOwnData | Permission.EditOwnData)]
    public void GetPermissions_ReturnsExpected(Berechtigungsstufe stufe, Permission expected)
    {
        var result = RolePermissionMapping.GetPermissions(stufe);
        result.Should().Be(expected);
    }
}
