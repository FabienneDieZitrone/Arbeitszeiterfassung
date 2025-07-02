/*
Titel: IPRangeValidatorTests
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Tests/IPRangeValidatorTests.cs
Beschreibung: Unit Tests fuer den IPRangeValidator
*/
using Xunit;
using Arbeitszeiterfassung.BLL.Validators;
/// <summary>
/// Testet die IP-Range Validierung.
/// </summary>
public class IPRangeValidatorTests
{
    [Theory]
    [InlineData("192.168.1.5", "192.168.1.0", "192.168.1.10", true)]
    [InlineData("192.168.2.5", "192.168.1.0", "192.168.1.10", false)]
    public void CheckRange(string ip, string start, string end, bool expected)
    {
        var validator = new IPRangeValidator();
        bool result = validator.IsInRange(ip, start, end);
        Assert.Equal(expected, result);
    }
}
