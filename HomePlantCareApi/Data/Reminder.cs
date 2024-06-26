namespace Web_Application_for_Home_Plant_Care.Models
{
    public class Reminder
    {
        public int ReminderID { get; set; }
        public int PlantID { get; set; }
        public Plant Plant { get; set; }
        public DateTime ReminderDate { get; set; }
        public string ReminderType { get; set; }
        public bool IsCompleted { get; set; }
    }
}
