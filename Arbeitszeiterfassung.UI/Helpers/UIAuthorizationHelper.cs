/*
Titel: UIAuthorizationHelper
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Helpers/UIAuthorizationHelper.cs
Beschreibung: Hilfen zur Steuerung der UI basierend auf Rollen
*/

using System.Windows.Forms;
using System.Linq;
using Arbeitszeiterfassung.Common.Enums;
using Arbeitszeiterfassung.DAL.Models;

namespace Arbeitszeiterfassung.UI.Helpers;

/// <summary>
/// Passt Steuerelemente an die Benutzerrolle an.
/// </summary>
public class UIAuthorizationHelper
{
    public void ConfigureControlsForUser(Form form, Benutzer user)
    {
        var btnStammdaten = form.Controls.Find("btnStammdaten", true).FirstOrDefault();
        if (btnStammdaten != null)
        {
            btnStammdaten.Visible = user.Rolle?.Berechtigungsstufe >= Berechtigungsstufe.Standortleiter;
        }
    }
}
