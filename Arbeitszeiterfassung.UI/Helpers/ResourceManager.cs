---
title: ResourceManager.cs
version: 1.0
lastUpdated: 08.07.2025
author: Tanja Trella
status: In Bearbeitung
file: /Arbeitszeiterfassung.UI/Helpers/ResourceManager.cs
description: Lädt Bilder und Icons für die UI
---

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
