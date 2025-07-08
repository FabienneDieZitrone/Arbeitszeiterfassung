/*
Titel: EskalationsManager
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Workflow/EskalationsManager.cs
Beschreibung: Kuemmert sich um Eskalationen
*/
using Arbeitszeiterfassung.BLL.Interfaces;

namespace Arbeitszeiterfassung.BLL.Workflow;

/// <summary>
/// Einfache Platzhalterimplementierung des Eskalationsmanagers.
/// </summary>
public class EskalationsManager : IEskalationsManager
{
    public Task PruefeUndEskaliereAsync() => Task.CompletedTask;
}
