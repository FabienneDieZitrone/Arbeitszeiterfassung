/*
Titel: IPRangeValidator
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Validators/IPRangeValidator.cs
Beschreibung: Validiert IP-Adressen gegen gespeicherte Bereiche
*/

using System.Net;
namespace Arbeitszeiterfassung.BLL.Validators;

/// <summary>
/// Prueft, ob eine IP-Adresse innerhalb eines Bereichs liegt.
/// </summary>
public class IPRangeValidator
{
    /// <summary>
    /// Statische Hilfsmethode fuer Vergleiche ohne Instanz.
    /// </summary>
    public static bool IsInRangeStatic(string ip, string? start, string? end)
        => new IPRangeValidator().IsInRange(ip, start, end);

    /// <summary>
    /// Prueft die IP innerhalb des Bereichs.
    /// </summary>
    public bool IsInRange(string ip, string? start, string? end)
    {
        if (string.IsNullOrWhiteSpace(start) || string.IsNullOrWhiteSpace(end))
            return false;

        IPAddress ipAddr = IPAddress.Parse(ip);
        IPAddress startAddr = IPAddress.Parse(start);
        IPAddress endAddr = IPAddress.Parse(end);
        byte[] ipBytes = ipAddr.GetAddressBytes();
        byte[] startBytes = startAddr.GetAddressBytes();
        byte[] endBytes = endAddr.GetAddressBytes();

        bool greaterOrEqual = true;
        bool lessOrEqual = true;

        for (int i = 0; i < ipBytes.Length && (greaterOrEqual || lessOrEqual); i++)
        {
            if (greaterOrEqual && ipBytes[i] < startBytes[i])
                greaterOrEqual = false;
            if (lessOrEqual && ipBytes[i] > endBytes[i])
                lessOrEqual = false;
        }

        return greaterOrEqual && lessOrEqual;
    }
}
