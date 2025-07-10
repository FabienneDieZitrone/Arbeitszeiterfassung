/*
---
title: StartPageControl.Designer.cs
version: 1.0
lastUpdated: 08.07.2025
author: Tanja Trella
status: In Bearbeitung
file: /Arbeitszeiterfassung.UI/Controls/StartPageControl.Designer.cs
description: Designer-Code für die StartPageControl
---
*/

using System;
using System.Drawing;
using System.Windows.Forms;


namespace Arbeitszeiterfassung.UI.Controls
{
    partial class StartPageControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblGreeting;
        private Button btnStartStop;
        private Panel panelQuickLinks;
        private Label lblArbeitszeit;

        /// <summary>
        /// Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">true, wenn verwaltete Ressourcen gelöscht werden sollen.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Designer generierter Code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblGreeting = new Label();
            btnStartStop = new Button();
            panelQuickLinks = new Panel();
            lblArbeitszeit = new Label();
            SuspendLayout();
            // 
            // lblGreeting
            // 
            lblGreeting.AutoSize = true;
            lblGreeting.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblGreeting.Location = new System.Drawing.Point(20, 20);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new System.Drawing.Size(208, 32);
            lblGreeting.TabIndex = 0;
            lblGreeting.Text = "Willkommen, User";
            // 
            // btnStartStop
            // 
            btnStartStop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnStartStop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnStartStop.Location = new System.Drawing.Point(350, 70);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new System.Drawing.Size(150, 50);
            btnStartStop.TabIndex = 1;
            btnStartStop.Text = "Start";
            btnStartStop.UseVisualStyleBackColor = true;
            // 
            // panelQuickLinks
            // 
            panelQuickLinks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panelQuickLinks.Location = new System.Drawing.Point(20, 140);
            panelQuickLinks.Name = "panelQuickLinks";
            panelQuickLinks.Size = new System.Drawing.Size(810, 40);
            panelQuickLinks.TabIndex = 2;
            // 
            // lblArbeitszeit
            // 
            lblArbeitszeit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            lblArbeitszeit.AutoSize = true;
            lblArbeitszeit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblArbeitszeit.Location = new System.Drawing.Point(370, 200);
            lblArbeitszeit.Name = "lblArbeitszeit";
            lblArbeitszeit.Size = new System.Drawing.Size(110, 28);
            lblArbeitszeit.TabIndex = 3;
            lblArbeitszeit.Text = "00:00:00";
            // 
            // StartPageControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(lblArbeitszeit);
            Controls.Add(panelQuickLinks);
            Controls.Add(btnStartStop);
            Controls.Add(lblGreeting);
            Name = "StartPageControl";
            Size = new System.Drawing.Size(850, 250);
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
