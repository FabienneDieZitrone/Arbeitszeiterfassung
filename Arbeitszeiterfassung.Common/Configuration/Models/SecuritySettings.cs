/*
Titel: SecuritySettings
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Configuration/Models/SecuritySettings.cs
Beschreibung: Sicherheitseinstellungen der Anwendung.
*/

namespace Arbeitszeiterfassung.Common.Configuration.Models;

/// <summary>
/// Einstellungen zur Sicherheit und Protokollierung.
/// </summary>
public class SecuritySettings
{
    public bool RequireIPValidation { get; set; } = true;
    public bool AllowOfflineMode { get; set; } = true;
    public int MaxLoginAttempts { get; set; } = 3;
    public bool EnableAuditLog { get; set; } = true;
}
