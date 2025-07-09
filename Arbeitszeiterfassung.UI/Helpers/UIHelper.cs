/*
Titel: UIHelper.cs
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.UI/Helpers/UIHelper.cs
Beschreibung: Methoden zur Vereinheitlichung des UI-Designs
*/

using System.Drawing;
using System.Windows.Forms;

namespace Arbeitszeiterfassung.UI.Helpers;

/// <summary>
/// Hilfsmethoden für UI-Elemente.
/// </summary>
public static class UIHelper
{
    private static readonly Color PrimaryColor = Color.FromArgb(0, 51, 102);
    private static readonly Color AccentColor = Color.FromArgb(255, 102, 0);

    /// <summary>
    /// Wendet das Farbchema auf das angegebene Control an.
    /// </summary>
    public static void ApplyColorScheme(Control control)
    {
        control.BackColor = PrimaryColor;
        control.ForeColor = Color.White;
        foreach (Control child in control.Controls)
        {
            child.ForeColor = Color.White;
        }
    }

    /// <summary>
    /// Hebt einen Button mit der Akzentfarbe hervor.
    /// </summary>
    public static void StyleAccentButton(Button button)
    {
        button.BackColor = AccentColor;
        button.ForeColor = Color.White;
        button.FlatStyle = FlatStyle.Flat;
    }
}
