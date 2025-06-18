---
title: Prompt für Schritt 1.1 - Projekt-Setup und Verzeichnisstruktur
description: Detaillierter Prompt zur Erstellung der grundlegenden Projektstruktur
author: Tanja Trella
version: 1.0
lastUpdated: 26.01.2025
category: Entwicklung
---

# Prompt für Schritt 1.1: Projekt-Setup und Verzeichnisstruktur

## Aufgabe
Erstelle die grundlegende Projektstruktur für eine Arbeitszeiterfassungsanwendung mit C# (.NET 9.0) als Windows Forms Anwendung.

## Technische Anforderungen
- .NET 9.0 mit C# 13.0
- Windows Forms für die UI
- Entity Framework Core für Datenzugriff
- 3-Schichten-Architektur (Presentation, Business Logic, Data Access)
- SQLite für Offline-Speicherung
- MySQL/MariaDB als Hauptdatenbank

## Zu erstellende Struktur
```
Arbeitszeiterfassung/
├── Arbeitszeiterfassung.sln
├── Arbeitszeiterfassung.UI/
│   ├── Arbeitszeiterfassung.UI.csproj
│   ├── Program.cs
│   ├── Forms/
│   │   ├── MainForm.cs
│   │   ├── MainForm.Designer.cs
│   │   └── MainForm.resx
│   ├── Resources/
│   │   └── mp-logo.png
│   └── App.config
├── Arbeitszeiterfassung.BLL/
│   ├── Arbeitszeiterfassung.BLL.csproj
│   ├── Services/
│   ├── Validators/
│   └── Interfaces/
├── Arbeitszeiterfassung.DAL/
│   ├── Arbeitszeiterfassung.DAL.csproj
│   ├── Models/
│   ├── Context/
│   ├── Repositories/
│   └── Interfaces/
├── Arbeitszeiterfassung.Common/
│   ├── Arbeitszeiterfassung.Common.csproj
│   ├── Enums/
│   ├── Constants/
│   └── Helpers/
└── Configuration/
    └── standorte.json
```

## Spezifische Anforderungen
1. Erstelle eine .NET 9.0 Solution mit vier Projekten
2. Konfiguriere die Projektabhängigkeiten korrekt
3. Füge notwendige NuGet-Pakete hinzu:
   - Entity Framework Core 9.x
   - Entity Framework Core SQLite
   - Entity Framework Core MySQL
   - Newtonsoft.Json
4. Erstelle eine Basis-App.config mit Platzhaltern für Connection Strings
5. Implementiere die Program.cs mit grundlegender Fehlerbehandlung
6. Erstelle ein leeres MainForm mit MP-Logo-Platzhalter

## Benötigte Dateien
Keine - dies ist der erste Schritt

## Erwartete Ausgabe
- Vollständige Solution-Datei (.sln)
- Alle .csproj Dateien mit korrekten Referenzen
- Program.cs mit Basis-Implementation
- MainForm (cs, Designer.cs, resx) mit Grundstruktur
- App.config mit Connection String Templates
- standorte.json mit Beispielstruktur

## Hinweise
- Verwende durchgehend deutsche Kommentare
- Jede Datei muss einen YAML-Header enthalten
- Implementiere bereits grundlegende Fehlerbehandlung
- Stelle sicher, dass die Anwendung als Einzeldatei deployed werden kann