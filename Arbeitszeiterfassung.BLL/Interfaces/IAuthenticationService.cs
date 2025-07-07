/*
Titel: IAuthenticationService
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Interfaces/IAuthenticationService.cs
Beschreibung: Schnittstelle fuer die Benutzerauthentifizierung
*/

namespace Arbeitszeiterfassung.BLL.Interfaces;
using Arbeitszeiterfassung.DAL.Models;

/// <summary>
/// Definiert Methoden zur Authentifizierung und Standortermittlung.
/// </summary>
public interface IAuthenticationService
{
    /// <summary>Fuehrt die Authentifizierung durch.</summary>
    Task<Benutzer> AuthenticateAsync();

    /// <summary>Ueberprueft die IP-Adresse gegen hinterlegte Bereiche.</summary>
    Task<bool> ValidateIPRangeAsync(string ipAddress);

    /// <summary>Ermittelt den Standort anhand der IP-Adresse.</summary>
    Task<Standort?> GetStandortByIPAsync(string ipAddress);

    /// <summary>Legt einen Benutzer an oder aktualisiert ihn.</summary>
    Task<Benutzer> CreateOrUpdateBenutzerAsync(string username);
}
