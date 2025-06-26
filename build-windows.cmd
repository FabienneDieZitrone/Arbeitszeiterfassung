@echo off
REM ---
REM title: Build Script Windows
REM version: 1.0
REM lastUpdated: 26.06.2025
REM author: Tanja Trella
REM status: In Bearbeitung
REM file: /build-windows.cmd
REM description: Bauen und Testen des Projekts unter Windows
REM ---

REM Dotnet Windows Desktop workload installieren
call dotnet workload install windowsdesktop

REM Projekt wiederherstellen und bauen
call dotnet restore Arbeitszeiterfassung.sln
call dotnet build Arbeitszeiterfassung.sln -c Debug

REM Unit-Tests ausfuehren
call dotnet test Arbeitszeiterfassung.sln

pause
