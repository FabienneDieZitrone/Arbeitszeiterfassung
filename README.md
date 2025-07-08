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
2. Schritt 3.4 ausfuehren (Genehmigungsworkflow)
3. Prompt verwenden: `..\Prompts\Schritt_3_4_Genehmigungsworkflow.md`

## Codex Setup Script

Um sicherzustellen, dass das .NET 8 SDK in jeder Codex-Session verfügbar ist, gibt es das Skript `setup.sh` im Projektstamm. Dieses installiert das SDK automatisch, falls es noch nicht vorhanden ist.

Öffne in deinen Codex-Projekt-Einstellungen den Bereich **Setup Commands** und trage dort den folgenden Befehl ein. Dadurch startet das Skript automatisch zu Beginn jeder Session:

```bash
bash setup.sh
```

Danach steht `dotnet` mit Version 8 automatisch zur Verfügung.

Um das Projekt unter Windows zu bauen und die Unit-Tests auszuführen, kann das Skript `build-windows.cmd` genutzt werden. Es installiert die erforderliche Windows-Desktop-Workload und führt anschließend `dotnet build` sowie `dotnet test` aus.

Für Linux/WSL-Systeme steht das Prüfskript `meta/test-projekt.sh` bereit. Dieses überprüft die Projektstruktur, führt einen Build aus und liefert eine Zusammenfassung der Testergebnisse. Bitte sende mir die Konsolenausgabe eines dieser Skripte als Bestätigung der erfolgreichen Tests auf deinem Zielsystem.

## Testergebnisse

Die letzte Ausführung auf dem Zielsystem ergab folgende Ausgabe:

```
Build succeeded with 6 warnings (CA1416, CS0067)
Passed!  - Failed: 0, Passed: 6
```

Nach den vorgenommenen Anpassungen baut das Projekt nun ohne Warnungen:

```
Build succeeded
Passed!  - Failed: 0, Passed: 6
```

## Schrittabschluss

Ein Schritt gilt erst als vollendet, wenn der Benutzer die entsprechenden Änderungen auf seinem Zielsystem getestet und positiv bestätigt hat. Solange diese Rückmeldung fehlt, wird der Schritt nicht als abgeschlossen markiert.

Antworte immer auf deutsch!
