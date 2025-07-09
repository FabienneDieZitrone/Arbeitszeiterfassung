/*
Titel: StartPageControl.cs
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.UI/Controls/StartPageControl.cs
Beschreibung: Startseite mit Begrüßung und Start/Stopp Button
*/


using System;
using System.Windows.Forms;
using System.Drawing;
using Arbeitszeiterfassung.UI.Helpers;

namespace Arbeitszeiterfassung.UI.Controls;

/// <summary>
/// Benutzersteuerung für die Startseite.
/// </summary>
public partial class StartPageControl : UserControl
{
    /// <summary>Erstellt die StartPageControl.</summary>
    public StartPageControl()
    {
        InitializeComponent();
        lblGreeting.Text = $"Willkommen, {Environment.UserName}";
        UIHelper.StyleAccentButton(btnStartStop);
        UIHelper.ApplyColorScheme(this);
    }
}
