/*
---
title: MainForm.cs
version: 1.1
lastUpdated: 08.07.2025
author: Tanja Trella
status: In Bearbeitung
file: /Arbeitszeiterfassung.UI/Forms/MainForm.cs
description: Hauptfenster der Anwendung mit Navigation und Statusleiste
---
*/

using System;
using System.Windows.Forms;
using Arbeitszeiterfassung.UI.Controls;
using Arbeitszeiterfassung.UI.Helpers;

namespace Arbeitszeiterfassung.UI.Forms;

/// <summary>
/// Hauptfenster der Anwendung. Stellt Navigation und Statusleiste bereit.
/// </summary>
public partial class MainForm : Form
{
    /// <summary>Initialisiert eine neue Instanz der <see cref="MainForm"/>.</summary>
    public MainForm()
    {
        InitializeComponent();
        Load += MainForm_Load;
        sessionTimer.Tick += SessionTimer_Tick;
    }

    private void MainForm_Load(object? sender, EventArgs e)
    {
        UIHelper.ApplyColorScheme(this);
        statusBarControl.SetUser(Environment.UserName, "Gast");
        Text = $"Arbeitszeiterfassung - {Environment.UserName}";
        NavigationHelper.ShowControl(new StartPageControl(), contentPanel);
        sessionTimer.Start();
    }

    private void SessionTimer_Tick(object? sender, EventArgs e)
    {
        statusBarControl.UpdateTime(DateTime.Now);
    }
}
