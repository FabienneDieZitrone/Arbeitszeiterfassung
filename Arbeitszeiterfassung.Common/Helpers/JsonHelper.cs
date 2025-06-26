/*
Titel: JsonHelper
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.Common/Helpers/JsonHelper.cs
Beschreibung: Hilfsklasse fuer JSON-Serialisierung und -Deserialisierung.
*/

using Newtonsoft.Json;

namespace Arbeitszeiterfassung.Common.Helpers;

/// <summary>
/// Bietet vereinfachte Methoden zum Lesen und Schreiben von JSON.
/// </summary>
public static class JsonHelper
{
    public static T? Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);

    public static string Serialize(object obj) => JsonConvert.SerializeObject(obj, Formatting.Indented);
}
