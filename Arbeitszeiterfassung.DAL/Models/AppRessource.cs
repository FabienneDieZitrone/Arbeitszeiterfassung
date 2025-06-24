/*
Titel: AppRessource Entity
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Models/AppRessource.cs
Beschreibung: Binaere Ressourcen der Anwendung
*/

using System.ComponentModel.DataAnnotations;

namespace Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Binaere Daten wie Firmenlogo.
/// </summary>
public class AppRessource : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Bezeichnung { get; set; } = string.Empty;

    public byte[] Daten { get; set; } = Array.Empty<byte>();

    public DateTime LetzteAktualisierung { get; set; } = DateTime.UtcNow;
}
