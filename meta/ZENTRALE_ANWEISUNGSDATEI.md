---
title: ZENTRALE_ANWEISUNGSDATEI.md - Anweisungen zur Arbeitszeiterfassung
description: Zentrale Anweisungsdatei bei der Entwicklung der Arbeitszeiterfassungsanwendung
author: Tanja Trella
version: 1.0
lastUpdated: 26.01.2025
category: Konfiguration
---

# ZENTRALE_ANWEISUNGSDATEI.md - Arbeitszeiterfassung Projekt

Diese Datei enthält alle Anweisungen und Kontextinformationen zur Fortsetzung der Entwicklung der Arbeitszeiterfassungsanwendung.

## Projektübersicht

**Projekt**: Standalone Arbeitszeiterfassungsanwendung für einen Bildungsträger
**Technologie**: C# 13.0 mit .NET 9.0, Windows Forms, Entity Framework Core
**Architektur**: 3-Schichten-Architektur (UI, BLL, DAL)
**Datenbanken**: MySQL/MariaDB (Haupt) + SQLite (Offline)

## Aktueller Projektstatus

### Bereits erstellt:
1. **Arbeitsplan_Arbeitszeiterfassung.md** - Vollständiger Entwicklungsplan mit 19 Schritten
2. **Prompts/** - Ordner mit 5 detaillierten Einzelprompts für die ersten Schritte
3. **Arbeitsplan_Bewertung.md** - Kritische Bewertung und Optimierungen
4. **Zusammenfassung_Arbeitsplan.md** - Executive Summary

### Nächste Schritte:
- **Aktuell**: Schritt 1.1 - Projekt-Setup und Verzeichnisstruktur
- **Prompt verfügbar in**: `/app/AZE/Prompts/Schritt_1_1_Projekt_Setup.md`

## Entwicklungsrichtlinien

### Code-Stil:
- **Sprache**: C# 13.0 (.NET 9.0)
- **Kommentare**: Deutsch
- **Namenskonventionen**: 
  - Klassen/Interfaces: PascalCase
  - Methoden: PascalCase
  - Variablen: camelCase
  - Konstanten: UPPER_CASE
- **Einrückung**: 4 Spaces (keine Tabs)

### Dokumentation:
- Jede Datei beginnt mit YAML-Header
- XML-Dokumentation für alle öffentlichen Members
- Inline-Kommentare für komplexe Logik
- Änderungshistorie in Kommentaren dokumentieren

### Dateistruktur:
```
/app/AZE/
├── ZENTRALE_ANWEISUNGSDATEI.md (diese Datei)
├── Arbeitsplan_Arbeitszeiterfassung.md
├── Arbeitsplan_Bewertung.md
├── Zusammenfassung_Arbeitsplan.md
├── Prompts/
│   ├── Schritt_1_1_Projekt_Setup.md
│   ├── Schritt_1_2_Datenbankdesign.md
│   ├── Schritt_2_1_Repository_Pattern.md
│   ├── Schritt_3_1_Benutzerauthentifizierung.md
│   └── Schritt_4_1_Hauptfenster.md
└── Arbeitszeiterfassung/ (wird erstellt)
    ├── Arbeitszeiterfassung.sln
    ├── Arbeitszeiterfassung.UI/
    ├── Arbeitszeiterfassung.BLL/
    ├── Arbeitszeiterfassung.DAL/
    └── Arbeitszeiterfassung.Common/
```

## Wichtige Anforderungen

### Funktional:
1. **Automatische Benutzeranmeldung** über Windows-Username
2. **IP-basierte Standorterkennung** (standorte.json)
3. **Offline-Fähigkeit** mit automatischer Synchronisation
4. **Rollenbasierte Berechtigungen** (5 Rollen)
5. **Genehmigungsworkflow** für nachträgliche Änderungen
6. **Vollständiges Audit-Trail**

### Technisch:
1. **Keine externen Abhängigkeiten** (Standalone)
2. **Single-File Deployment**
3. **Thread-Safe Implementation**
4. **Async/Await durchgängig**
5. **DSGVO-konform**

### UI-Anforderungen:
- MP-Logo in allen Fenstern
- Responsive Design
- Farbschema: Dunkelblau (#003366), Orange (#FF6600)
- Schriftart: Segoe UI
- Minimale Fenstergröße: 800x600

## Datenbank-Verbindung

**Produktionsdatenbank**: db10454681-aze
**Passwort**: Start.321
**Provider**: MySQL/MariaDB

## Befehle für neue Chat-Session

```bash
# Projektverzeichnis
cd /app/AZE

# Aktuellen Status prüfen
ls -la

# Nächsten Schritt ausführen
# Verwende Prompt aus: Prompts/Schritt_1_1_Projekt_Setup.md
```

## Kontinuierliche Aufgaben

1. **Nach jeder Datei-Erstellung**: YAML-Header hinzufügen
2. **Bei Code-Änderungen**: Kommentare aktualisieren
3. **Nach Feature-Completion**: Dokumentation updaten
4. **Vor Schritt-Abschluss**: Code-Review durchführen

## Hilfreiche Referenzen

- **Hauptplan**: `/app/AZE/Arbeitsplan_Arbeitszeiterfassung.md`
- **Nächster Prompt**: `/app/AZE/Prompts/Schritt_1_1_Projekt_Setup.md`
- **Bewertung**: `/app/AZE/Arbeitsplan_Bewertung.md`

## Spezielle Hinweise

1. **Entity Framework**: Verwende Code-First Approach
2. **Offline-Sync**: SQLite muss identische Struktur wie MySQL haben
3. **Sicherheit**: Keine Passwörter im Code, nur Windows-Auth
4. **Performance**: Lazy Loading vermeiden, Eager Loading bevorzugen
5. **Testing**: Mindestens 80% Code Coverage anstreben

Diese Datei dient als zentraler Einstiegspunkt für jede neue Session!