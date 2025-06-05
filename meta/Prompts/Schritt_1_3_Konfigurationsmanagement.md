---
title: Prompt für Schritt 1.3 - Konfigurationsmanagement
description: Detaillierter Prompt zur Einrichtung von App.config, standorte.json und Basis-Konfiguration
author: Tanja Trella
version: 1.0
lastUpdated: 26.01.2025
category: Entwicklung
---

# Prompt für Schritt 1.3: Konfigurationsmanagement

## Aufgabe
Erstelle das vollständige Konfigurationsmanagement für die Arbeitszeiterfassungsanwendung mit App.config, standorte.json und einem flexiblen Konfigurationssystem.

## Zu erstellende Komponenten

### 1. App.config (Arbeitszeiterfassung.UI)
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <connectionStrings>
    <!-- Haupt-Datenbank -->
    <!-- Offline-Datenbank -->
  </connectionStrings>
  <appSettings>
    <!-- Anwendungseinstellungen -->
  </appSettings>
</configuration>
```

### 2. standorte.json
Vollständige Standortkonfiguration mit:
- Standortdefinitionen
- IP-Range Mappings
- Home-Office Einstellungen
- VPN-Konfiguration

### 3. ConfigurationManager.cs
- Zentrale Konfigurationsverwaltung
- Strongly-typed Settings
- Hot-Reload Funktionalität
- Verschlüsselung sensibler Daten

### 4. AppSettings.cs
```csharp
public class AppSettings
{
    public DatabaseSettings Database { get; set; }
    public SyncSettings Synchronisation { get; set; }
    public UISettings UserInterface { get; set; }
    public SecuritySettings Security { get; set; }
    public NotificationSettings Notifications { get; set; }
}
```

### 5. EncryptionHelper.cs
- Connection String Verschlüsselung
- API-Key Schutz
- Sichere Speicherung mit DPAPI

### 6. ConfigValidator.cs
- Konfigurationsprüfung beim Start
- Pflichtfelder-Validierung
- IP-Range Format-Checks
- Wertebereiche prüfen

## Spezifische Konfigurationen

### Datenbank-Einstellungen:
```csharp
public class DatabaseSettings
{
    public string MainConnectionString { get; set; }
    public string OfflineConnectionString { get; set; }
    public int CommandTimeout { get; set; } = 30;
    public bool EnableLogging { get; set; } = false;
    public int MaxRetryCount { get; set; } = 3;
}
```

### Synchronisations-Einstellungen:
```csharp
public class SyncSettings
{
    public int IntervalSeconds { get; set; } = 30;
    public int BatchSize { get; set; } = 100;
    public bool AutoSyncEnabled { get; set; } = true;
    public int ConflictResolutionMode { get; set; } = 1; // 1=Server wins
}
```

### UI-Einstellungen:
```csharp
public class UISettings
{
    public string Theme { get; set; } = "Standard";
    public int SessionTimeoutMinutes { get; set; } = 30;
    public bool ShowToolTips { get; set; } = true;
    public string DateFormat { get; set; } = "dd.MM.yyyy";
    public string TimeFormat { get; set; } = "HH:mm:ss";
}
```

### Sicherheits-Einstellungen:
```csharp
public class SecuritySettings
{
    public bool RequireIPValidation { get; set; } = true;
    public bool AllowOfflineMode { get; set; } = true;
    public int MaxLoginAttempts { get; set; } = 3;
    public bool EnableAuditLog { get; set; } = true;
}
```

### Benachrichtigungs-Einstellungen:
```csharp
public class NotificationSettings
{
    public bool FridayCheck { get; set; } = true;
    public decimal OvertimeThresholdHours { get; set; } = 1.0m;
    public bool ShowSyncStatus { get; set; } = true;
    public bool PlaySounds { get; set; } = false;
}
```

## Erweiterte Features

### 1. Umgebungsspezifische Konfiguration
- Development.config
- Production.config
- Automatische Umgebungserkennung

### 2. Konfigurationsmigration
- Versions-Upgrade-Mechanismus
- Backup alter Einstellungen
- Automatische Konvertierung

### 3. Benutzer-Overrides
- Lokale Benutzereinstellungen
- Roaming Profile Support
- Import/Export Funktionalität

## Beispiel standorte.json:
```json
{
  "version": "1.0",
  "lastModified": "2025-01-26T10:00:00",
  "standorte": [
    {
      "id": 1,
      "name": "Hauptsitz Berlin",
      "kuerzel": "BER",
      "adresse": {
        "strasse": "Beispielstraße 1",
        "plz": "10115",
        "ort": "Berlin"
      },
      "ipRanges": [
        {
          "start": "192.168.1.1",
          "end": "192.168.1.254",
          "subnet": "192.168.1.0/24",
          "beschreibung": "Hauptnetzwerk"
        }
      ],
      "telefon": "+49 30 12345678",
      "email": "berlin@mikropartner.de",
      "aktiv": true
    },
    {
      "id": 2,
      "name": "Filiale Hamburg",
      "kuerzel": "HAM",
      "adresse": {
        "strasse": "Musterweg 2",
        "plz": "20095",
        "ort": "Hamburg"
      },
      "ipRanges": [
        {
          "start": "192.168.2.1",
          "end": "192.168.2.254",
          "subnet": "192.168.2.0/24",
          "beschreibung": "Filial-Netzwerk"
        }
      ],
      "telefon": "+49 40 87654321",
      "email": "hamburg@mikropartner.de",
      "aktiv": true
    }
  ],
  "homeOffice": {
    "enabled": true,
    "requiresVPN": true,
    "vpnRanges": [
      {
        "start": "10.0.0.1",
        "end": "10.0.0.254",
        "subnet": "10.0.0.0/24",
        "provider": "OpenVPN"
      }
    ],
    "maxTageProWoche": 3
  },
  "netzwerkEinstellungen": {
    "timeoutSeconds": 5,
    "retryCount": 3,
    "checkInterval": 30
  }
}
```

## Benötigte Dateien
- Projektstruktur aus Schritt 1.1
- Entity-Modelle aus Schritt 1.2

## Erwartete Ausgabe
```
Configuration/
├── standorte.json
├── standorte.schema.json
Common/
├── Configuration/
│   ├── ConfigurationManager.cs
│   ├── AppSettings.cs
│   ├── ConfigValidator.cs
│   └── Models/
│       ├── DatabaseSettings.cs
│       ├── SyncSettings.cs
│       ├── UISettings.cs
│       ├── SecuritySettings.cs
│       └── NotificationSettings.cs
├── Helpers/
│   ├── EncryptionHelper.cs
│   └── JsonHelper.cs
UI/
├── App.config
├── App.Development.config
└── App.Production.config
```

## Hinweise
- Verwende System.Configuration für App.config
- Newtonsoft.Json für JSON-Verarbeitung
- DPAPI für Windows-Verschlüsselung
- FileSystemWatcher für Hot-Reload
- Singleton-Pattern für ConfigurationManager