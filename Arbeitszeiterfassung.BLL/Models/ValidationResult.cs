/*
Titel: ValidationResult
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Models/ValidationResult.cs
Beschreibung: Ergebnis einer Validierung mit moeglichen Fehlermeldungen
*/
using System.Linq;

namespace Arbeitszeiterfassung.BLL.Models;

/// <summary>
/// Ergebnisobjekt fuer Validierungen.
/// </summary>
public class ValidationResult
{
    public bool IsValid => !Errors.Any();
    public List<string> Errors { get; } = new();
}
