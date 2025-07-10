---
title: StartPageControl.cs
version: 1.0
lastUpdated: 08.07.2025
author: Tanja Trella
status: In Bearbeitung
file: /Arbeitszeiterfassung.UI/Controls/StartPageControl.cs
description: Startseite mit Begrüßung und Start/Stopp Button
---

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
