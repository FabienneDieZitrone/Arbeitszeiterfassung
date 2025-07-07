---
title: README
version: 1.3
lastUpdated: 26.06.2025
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
2. Schritt 3.1 ausfuehren (Benutzerauthentifizierung)
3. Prompt verwenden: `..\Prompts\Schritt_3_1_Benutzerauthentifizierung.md`

## Codex Setup Script

Um sicherzustellen, dass das .NET 8 SDK in jeder Codex-Session verfügbar ist, gibt es das Skript `setup.sh` im Projektstamm. Dieses installiert das SDK automatisch, falls es noch nicht vorhanden ist.

Öffne in deinen Codex-Projekt-Einstellungen den Bereich **Setup Commands** und trage dort den folgenden Befehl ein. Dadurch startet das Skript automatisch zu Beginn jeder Session:

```bash
bash setup.sh
```

Danach steht `dotnet` mit Version 8 automatisch zur Verfügung.

Um das Projekt unter Windows zu bauen und die Unit-Tests auszuführen, kann das Skript `build-windows.cmd` genutzt werden. Es installiert die erforderliche Windows-Desktop-Workload und führt anschliessend `dotnet build` sowie `dotnet test` aus. Die Konsolenausgabe des Skripts kann zur Validierung an mich zurückgegeben werden.

## Schrittabschluss

Ein Schritt gilt erst als vollendet, wenn der Benutzer die entsprechenden Änderungen auf seinem Zielsystem getestet und positiv bestätigt hat. Solange diese Rückmeldung fehlt, wird der Schritt nicht als abgeschlossen markiert.

Antworte immer auf deutsch!
