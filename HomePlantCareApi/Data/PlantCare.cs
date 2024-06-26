namespace Web_Application_for_Home_Plant_Care.Models
{
    public class PlantCare
    {
        public int CareID { get; set; }
        public int PlantID { get; set; }
        public Plant Plant { get; set; }
        public DateTime CareDate { get; set; }
        public string CareType { get; set; }
    }
}
