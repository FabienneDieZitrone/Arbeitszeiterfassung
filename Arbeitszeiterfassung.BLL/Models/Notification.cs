/*
Titel: Notification Model
Version: 1.0
Letzte Aktualisierung: 08.07.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.BLL/Models/Notification.cs
Beschreibung: Benachrichtigung im Genehmigungsworkflow
*/
using Arbeitszeiterfassung.Common.Enums;

namespace Arbeitszeiterfassung.BLL.Models;

/// <summary>
/// Modell fuer Benachrichtigungen im Workflow.
/// </summary>
public class Notification
{
    public int EmpfaengerID { get; set; }
    public NotificationType Typ { get; set; }
    public string Titel { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int ReferenzID { get; set; }
    public string ReferenzTyp { get; set; } = string.Empty;
    public DateTime ErstelltAm { get; set; }
}
