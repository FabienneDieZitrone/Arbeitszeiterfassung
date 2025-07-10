/*
---
title: StatusBarControl.cs
version: 1.0
lastUpdated: 08.07.2025
author: Tanja Trella
status: In Bearbeitung
file: /Arbeitszeiterfassung.UI/Controls/StatusBarControl.cs
description: Statusleiste mit Benutzerinformationen und Uhrzeit
---
*/

using System;
using System.Windows.Forms;
using System.Drawing;

namespace Arbeitszeiterfassung.UI.Controls;

/// <summary>
/// Benutzersteuerung für die Statusleiste.
/// </summary>
public partial class StatusBarControl : UserControl
{
    /// <summary>Erstellt die StatusBarControl.</summary>
    public StatusBarControl()
    {
        InitializeComponent();
    }

    /// <summary>Setzt den Benutzer anzuzeigende Informationen.</summary>
    public void SetUser(string username, string rolle)
    {
        lblUser.Text = $"{username} ({rolle})";
    }

    /// <summary>Aktualisiert die angezeigte Uhrzeit.</summary>
    public void UpdateTime(DateTime time)
    {
        lblTime.Text = time.ToString("HH:mm:ss");
    }
}
