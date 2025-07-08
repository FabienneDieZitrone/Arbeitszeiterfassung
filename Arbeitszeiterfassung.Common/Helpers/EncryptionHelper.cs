/*
Titel: EncryptionHelper
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Helpers/EncryptionHelper.cs
Beschreibung: Hilfsklasse zur Verschluesselung sensibler Daten mittels DPAPI.
*/

using System.Security.Cryptography;
using System.Text;
using System.Runtime.Versioning;

namespace Arbeitszeiterfassung.Common.Helpers;

/// <summary>
/// Stellt einfache Methoden zur Verschluesselung und Entschluesselung bereit.
/// </summary>
[SupportedOSPlatform("windows")]
public static class EncryptionHelper
{
    public static string Encrypt(string plainText)
    {
        byte[] data = Encoding.UTF8.GetBytes(plainText);
        byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
        return Convert.ToBase64String(encrypted);
    }

    public static string Decrypt(string cipherText)
    {
        byte[] data = Convert.FromBase64String(cipherText);
        byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
        return Encoding.UTF8.GetString(decrypted);
    }
}
