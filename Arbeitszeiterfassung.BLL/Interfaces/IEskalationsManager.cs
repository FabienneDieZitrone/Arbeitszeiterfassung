/*
Titel: IEskalationsManager
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Interfaces/IEskalationsManager.cs
Beschreibung: Schnittstelle fuer Eskalationsmechanismen
*/

namespace Arbeitszeiterfassung.BLL.Interfaces;

/// <summary>
/// Definiert die Eskalationslogik fuer offene Antraege.
/// </summary>
public interface IEskalationsManager
{
    Task PruefeUndEskaliereAsync();
}
