/*
Titel: BerechtigungsAudit
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Authorization/BerechtigungsAudit.cs
Beschreibung: Fuehrt ein Berechtigungs-Audit-Log
*/

using Arbeitszeiterfassung.BLL.Models;
using Arbeitszeiterfassung.Common.Enums;
using Arbeitszeiterfassung.BLL.Interfaces;

namespace Arbeitszeiterfassung.BLL.Authorization;

/// <summary>
/// Zeichnet durchgefuehrte Berechtigungspruefungen auf.
/// </summary>
public class BerechtigungsAudit
{
    private readonly ISessionManager _sessionManager;
    private readonly List<BerechtigungsAuditLog> _entries = new();

    public BerechtigungsAudit(ISessionManager sessionManager)
    {
        _sessionManager = sessionManager;
    }

    public Task LogPermissionCheckAsync(
        int benutzerId,
        Permission permission,
        bool granted,
        string context)
    {
        var auditEntry = new BerechtigungsAuditLog
        {
            BenutzerID = benutzerId,
            Permission = permission.ToString(),
            Granted = granted,
            Context = context,
            Timestamp = DateTime.Now,
            SessionID = Guid.NewGuid()
        };

        _entries.Add(auditEntry);
        return Task.CompletedTask;
    }

    public IReadOnlyCollection<BerechtigungsAuditLog> Entries => _entries.AsReadOnly();
}
