---
title: README
version: 2.0
lastUpdated: 08.07.2025
author: Tanja Trella
status: In Bearbeitung
file: /README.md
description: Kurze Projektuebersicht
---

# Arbeitszeiterfassung

Dieses Projekt dient der Erfassung und Verwaltung von Arbeitszeiten. Es wurde automatisch mit `init-projekt-v3.bat` erstellt.
Alle wichtigen Anweisungen findest du im Ordner `meta/`.
Folgende Dateien sind fuer den Projekterfolg besonders relevant:
1. `meta/ZENTRALE_ANWEISUNGSDATEI.md`
2. `meta/BEST_PRACTICES.md`
3. `meta/ENTWICKLER_CHECKLISTE.md`
4. `meta/README.md`

## Aktueller Stand
Die Basis-Struktur mit BLL, DAL und UI steht. Das Konfigurationsmanagement (Schritt 1.3) ist abgeschlossen. Das Repository-Pattern (Schritt 2.1) und die Vorbereitung der Offline-Synchronisation mit SQLite (Schritt 2.2) wurden umgesetzt. Weitere Geschäftslogik wird schrittweise ergänzt.

## Naechste Schritte
1. Visual Studio oeffnen: `start Arbeitszeiterfassung.sln`
2. Schritt 4.1 ausfuehren (Hauptfenster)
3. Prompt verwenden: `..\Prompts\Schritt_4_1_Hauptfenster.md`

## Codex Setup Script

Um sicherzustellen, dass das .NET 8 SDK in jeder Codex-Session verfügbar ist, gibt es das Skript `setup.sh` im Projektstamm. Dieses installiert das SDK automatisch, falls es noch nicht vorhanden ist.

Öffne in deinen Codex-Projekt-Einstellungen den Bereich **Setup Commands** und trage dort den folgenden Befehl ein. Dadurch startet das Skript automatisch zu Beginn jeder Session:

```bash
bash setup.sh
```

Danach steht `dotnet` mit Version 8 automatisch zur Verfügung.

Um das Projekt unter Windows zu bauen und die Unit-Tests auszuführen, kann das Skript `build-windows.cmd` genutzt werden. Es installiert die erforderliche Windows-Desktop-Workload und führt anschließend `dotnet build` sowie `dotnet test` aus. Das UI-Projekt lässt sich ausschließlich unter Windows kompilieren, weil das `Microsoft.NET.Sdk.WindowsDesktop` benötigt wird. Unter Linux wird dieses Projekt daher im Prüfskript übersprungen.

Nach dem Build befindet sich die ausführbare Datei unter:

```
Arbeitszeiterfassung.UI\bin\Debug\net8.0-windows\win-x64\Arbeitszeiterfassung.UI.exe
```
Für Release-Builds entsprechend im `bin\Release`-Unterordner.

Für Linux/WSL-Systeme steht das Prüfskript `meta/test-projekt.sh` bereit. Dieses überprüft die Projektstruktur, führt einen Build aus und liefert eine Zusammenfassung der Testergebnisse. Bitte sende mir die Konsolenausgabe eines dieser Skripte als Bestätigung der erfolgreichen Tests auf deinem Zielsystem.

## Testergebnisse

Die letzte Ausführung auf dem Zielsystem ergab folgende Ausgabe:

```
======================================
Arbeitszeiterfassung Projekt Test
======================================
✓ Hauptverzeichnis existiert
✓ Solution-Datei vorhanden
✓ Projekt Arbeitszeiterfassung.Common existiert
✓ Projekt Arbeitszeiterfassung.DAL existiert
✓ Projekt Arbeitszeiterfassung.BLL existiert
✓ Projekt Arbeitszeiterfassung.UI existiert
✓ Projekt Arbeitszeiterfassung.Tests existiert
✓ DAL referenziert Common
✓ BLL referenziert Common
✓ BLL referenziert DAL
✓ UI referenziert Common
✓ UI referenziert DAL
✓ UI referenziert BLL
✓ appsettings.json vorhanden
✓ .gitignore vorhanden
✓ Entity Framework Core in DAL
✓ Configuration Extensions in Common
✓ xUnit in Tests
✓ Arbeitszeiterfassung.Common lässt sich bauen
✓ Arbeitszeiterfassung.DAL lässt sich bauen
✓ Arbeitszeiterfassung.BLL lässt sich bauen
✓ Arbeitszeiterfassung.Tests lässt sich bauen
✓ UI-Projekt vorhanden
✓ Arbeitszeiterfassung.Common wurde gebaut
✓ Arbeitszeiterfassung.DAL wurde gebaut
✓ Arbeitszeiterfassung.BLL wurde gebaut
✓ Arbeitszeiterfassung.Tests wurde gebaut
✓ Unit-Tests erfolgreich
✓ Common/Configuration existiert
✓ Common/Enums existiert
✓ Common/Extensions existiert
✓ Common/Helpers existiert
✓ Common/Models existiert
✓ DAL/Context existiert
✓ DAL/Entities existiert
✓ DAL/Migrations existiert
✓ DAL/Repositories existiert
✓ Alle Tests bestanden!
```
Das Projekt ist bereit für die Entwicklung.
Nächster Schritt: Hauptfenster implementieren
Verwenden Sie: /app/AZE/Prompts/Schritt_4_1_Hauptfenster.md

## Schrittabschluss

Ein Schritt gilt erst als vollendet, wenn der Benutzer die entsprechenden Änderungen auf seinem Zielsystem getestet und positiv bestätigt hat. Nach jedem Schritt erfolgt außerdem eine selbstkritische Bewertung auf einer Skala von 1-10. Nur wenn keine Verbesserungsmöglichkeiten mehr offen sind und das Ergebnis die Bestnote 10 erreicht, wird der Schritt als abgeschlossen dokumentiert.

Antworte immer auf deutsch!
