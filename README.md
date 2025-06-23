# Arbeitszeiterfassung

Dieses Projekt dient der Erfassung und Verwaltung von Arbeitszeiten. Es wurde automatisch mit `init-projekt-v3.bat` erstellt.

## Aktueller Stand
Die Projektstruktur mit BLL, DAL und UI ist angelegt, enthält jedoch überwiegend Platzhalter. Die Implementierung der Geschäftslogik und der Datenzugriffsschicht befindet sich noch im Aufbau.

## Naechste Schritte
1. Visual Studio oeffnen: `start Arbeitszeiterfassung.sln`
2. Schritt 1.2 ausfuehren (Datenbankdesign)
3. Prompt verwenden: `..\Prompts\Schritt_1_2_Datenbankdesign.md`

## Codex Setup Script

Um sicherzustellen, dass das .NET 8 SDK in jeder Codex-Session verfügbar ist, gibt es das Skript `setup.sh` im Projektstamm. Dieses installiert das SDK automatisch, falls es noch nicht vorhanden ist.

Öffne in deinen Codex-Projekt-Einstellungen den Bereich **Setup Commands** und trage dort den folgenden Befehl ein. Dadurch startet das Skript automatisch zu Beginn jeder Session:

```bash
bash setup.sh
```

Danach steht `dotnet` mit Version 8 automatisch zur Verfügung.
