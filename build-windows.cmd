@echo off
REM ---
REM title: Build Script Windows
REM version: 1.1
REM lastUpdated: 26.06.2025
REM author: Tanja Trella
REM status: In Bearbeitung
REM file: /build-windows.cmd
REM description: Bauen und Testen des Projekts unter Windows
REM ---

REM Windows Desktop Workload sicherstellen
call dotnet workload install microsoft-net-sdk-windowsdesktop >nul 2>&1
if %ERRORLEVEL% neq 0 (
    echo Workload konnte nicht installiert werden oder ist bereits vorhanden.
)

REM Projekt wiederherstellen und bauen
call dotnet restore Arbeitszeiterfassung.sln
call dotnet build Arbeitszeiterfassung.sln -c Debug

REM Unit-Tests ausfuehren
call dotnet test Arbeitszeiterfassung.sln

pause
