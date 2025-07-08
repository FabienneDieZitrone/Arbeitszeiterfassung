/*
Titel: IDataAccessValidator
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Interfaces/IDataAccessValidator.cs
Beschreibung: Schnittstelle fuer Datenzugriffspruefungen
*/

using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.BLL.Interfaces;

/// <summary>
/// Prueft, ob Datenzugriff erlaubt ist.
/// </summary>
public interface IDataAccessValidator
{
    Task<bool> CanAccessUserDataAsync(Benutzer accessor, Benutzer target);
    Task<bool> HaveCommonStandortAsync(Benutzer accessor, Benutzer target);
}
