/*
Titel: NavigationHelper.cs
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.UI/Helpers/NavigationHelper.cs
Beschreibung: Helfer für das Navigieren zwischen UserControls
*/

using System.Windows.Forms;

namespace Arbeitszeiterfassung.UI.Helpers;

/// <summary>
/// Statische Methoden zur Navigation zwischen Views.
/// </summary>
public static class NavigationHelper
{
    /// <summary>
    /// Zeigt das angegebene Control im Zielpanel an.
    /// </summary>
    public static void ShowControl(UserControl control, Panel host)
    {
        foreach (Control c in host.Controls)
        {
            c.Dispose();
        }
        host.Controls.Clear();
        control.Dock = DockStyle.Fill;
        host.Controls.Add(control);
    }
}
