/*
Titel: Program.cs
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.UI/Program.cs
Beschreibung: Einstiegspunkt für die Windows Forms Anwendung mit grundlegender Fehlerbehandlung
*/

using System;
using System.Windows.Forms;

namespace Arbeitszeiterfassung.UI
{
    /// <summary>
    /// Einstiegspunkt für die Anwendung. 
    /// Setzt globale Fehlerbehandlung und startet das Hauptfenster.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Globale Fehlerbehandlung
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) =>
            {
                MessageBox.Show("Ein unerwarteter Fehler ist aufgetreten:\n" + e.Exception.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Fehler kann hier geloggt werden (später Logging-Service einbinden)
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Exception ex = e.ExceptionObject as Exception;
                MessageBox.Show("Ein schwerwiegender Fehler ist aufgetreten:\n" + (ex?.Message ?? "Unbekannter Fehler"), "Kritischer Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Fehler kann hier geloggt werden
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // TODO: Hier ggf. Login-/Splash-Logik einbauen
            Application.Run(new Forms.MainForm());
        }
    }
}
