namespace Web_Application_for_Home_Plant_Care.Models
{
    public class Plant
    {
        public int PlantID { get; set; }
        public string PlantName { get; set; }
        public int PlantTypeID { get; set; }
        public PlantType PlantType { get; set; }
        public string PlantDescription { get; set; }
        public DateTime DateLastWatering { get; set; }
        public DateTime DateLastTransplant { get; set; }
        public ICollection<PlantCare> PlantCares { get; set; }
        public ICollection<Reminder> Reminders { get; set; }
    }
}
