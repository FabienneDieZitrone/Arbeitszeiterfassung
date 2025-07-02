/*
Titel: ConfigValidator
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Configuration/ConfigValidator.cs
Beschreibung: Validiert die geladenen Konfigurationseinstellungen.
*/

using System.Collections.Generic;
using Arbeitszeiterfassung.Common.Configuration.Models;

namespace Arbeitszeiterfassung.Common.Configuration;

/// <summary>
/// Prueft die AppSettings auf Gueltigkeit.
/// </summary>
public static class ConfigValidator
{
    public static bool Validate(AppSettings settings, out List<string> errors)
    {
        errors = new();

        if (string.IsNullOrWhiteSpace(settings.Database.MainConnectionString))
            errors.Add("MainConnectionString darf nicht leer sein");

        if (string.IsNullOrWhiteSpace(settings.Database.OfflineConnectionString))
            errors.Add("OfflineConnectionString darf nicht leer sein");

        return errors.Count == 0;
    }
}
