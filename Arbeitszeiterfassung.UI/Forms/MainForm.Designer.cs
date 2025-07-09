/*
Titel: MainForm.Designer.cs
Version: 1.1
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.UI/Forms/MainForm.Designer.cs
Beschreibung: Designer-Code für das Hauptfenster mit Navigation
*/

namespace Arbeitszeiterfassung.UI.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.Panel contentPanel;
        private Controls.StatusBarControl statusBarControl;
        private System.Windows.Forms.Timer sessionTimer;
        private System.Windows.Forms.NotifyIcon trayIcon;

        /// <summary>
        /// Ressourcenbereinigung.
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

        #region Vom Windows Form-Designer generierter Code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBoxLogo = new System.Windows.Forms.PictureBox();
            mainToolStrip = new System.Windows.Forms.ToolStrip();
            contentPanel = new System.Windows.Forms.Panel();
            statusBarControl = new Controls.StatusBarControl();
            sessionTimer = new System.Windows.Forms.Timer(components);
            trayIcon = new System.Windows.Forms.NotifyIcon(components);
            ((System.ComponentModel.ISupportInitialize)(pictureBoxLogo)).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = null;
            pictureBoxLogo.Location = new System.Drawing.Point(12, 12);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new System.Drawing.Size(120, 48);
            pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // mainToolStrip
            // 
            mainToolStrip.Location = new System.Drawing.Point(0, 0);
            mainToolStrip.Name = "mainToolStrip";
            mainToolStrip.Size = new System.Drawing.Size(900, 25);
            mainToolStrip.TabIndex = 1;
            mainToolStrip.Text = "toolStrip1";
            // 
            // contentPanel
            // 
            contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            contentPanel.Location = new System.Drawing.Point(12, 70);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new System.Drawing.Size(876, 520);
            contentPanel.TabIndex = 2;
            // 
            // statusBarControl
            // 
            statusBarControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            statusBarControl.Location = new System.Drawing.Point(0, 600);
            statusBarControl.Name = "statusBarControl";
            statusBarControl.Size = new System.Drawing.Size(900, 30);
            statusBarControl.TabIndex = 3;
            // 
            // sessionTimer
            // 
            sessionTimer.Interval = 1000;
            // 
            // trayIcon
            // 
            trayIcon.Text = "Arbeitszeiterfassung";
            trayIcon.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 51, 102);
            ClientSize = new System.Drawing.Size(900, 630);
            Controls.Add(statusBarControl);
            Controls.Add(contentPanel);
            Controls.Add(mainToolStrip);
            Controls.Add(pictureBoxLogo);
            Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MinimumSize = new System.Drawing.Size(800, 600);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Arbeitszeiterfassung";
            ((System.ComponentModel.ISupportInitialize)(pictureBoxLogo)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
