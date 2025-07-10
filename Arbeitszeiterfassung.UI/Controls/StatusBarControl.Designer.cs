/*

---
title: StatusBarControl.Designer.cs
version: 1.0
lastUpdated: 08.07.2025
author: Tanja Trella
status: In Bearbeitung
file: /Arbeitszeiterfassung.UI/Controls/StatusBarControl.Designer.cs
description: Designer-Code für StatusBarControl
---
*/

namespace Arbeitszeiterfassung.UI.Controls
{
    partial class StatusBarControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblUser;
        private Label lblStatus;
        private Label lblSync;
        private Label lblTime;

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
            lblUser = new Label();
            lblStatus = new Label();
            lblSync = new Label();
            lblTime = new Label();
            SuspendLayout();
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new System.Drawing.Point(10, 5);
            lblUser.Name = "lblUser";
            lblUser.Size = new System.Drawing.Size(150, 20);
            lblUser.TabIndex = 0;
            lblUser.Text = "Benutzer (Rolle)";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(300, 5);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(52, 20);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Online";
            // 
            // lblSync
            // 
            lblSync.AutoSize = true;
            lblSync.Location = new System.Drawing.Point(420, 5);
            lblSync.Name = "lblSync";
            lblSync.Size = new System.Drawing.Size(84, 20);
            lblSync.TabIndex = 2;
            lblSync.Text = "Synced";
            // 
            // lblTime
            // 
            lblTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblTime.AutoSize = true;
            lblTime.Location = new System.Drawing.Point(700, 5);
            lblTime.Name = "lblTime";
            lblTime.Size = new System.Drawing.Size(80, 20);
            lblTime.TabIndex = 3;
            lblTime.Text = "00:00:00";
            // 
            // StatusBarControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(lblTime);
            Controls.Add(lblSync);
            Controls.Add(lblStatus);
            Controls.Add(lblUser);
            Dock = System.Windows.Forms.DockStyle.Bottom;
            Name = "StatusBarControl";
            Size = new System.Drawing.Size(800, 30);
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
