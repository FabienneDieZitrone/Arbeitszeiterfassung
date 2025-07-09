/*
Titel: ResourceManager.cs
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.UI/Helpers/ResourceManager.cs
Beschreibung: Lädt Bilder und Icons für die UI
*/

using System.Drawing;
using System.IO;

namespace Arbeitszeiterfassung.UI.Helpers;

/// <summary>
/// Vereinfacht das Laden von Ressourcen wie Bildern und Icons.
/// </summary>
public static class ResourceManager
{
    /// <summary>
    /// Lädt ein Icon aus einem Byte-Array.
    /// </summary>
    public static Icon? LoadIcon(byte[]? data)
    {
        if (data == null)
            return null;
        using MemoryStream ms = new(data);
        return new Icon(ms);
    }
}
