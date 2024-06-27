namespace Web_Application_for_Home_Plant_Care.Models
{
    public class PlantType
    {
        public int PlantTypeID { get; set; }
        public string PlantTypeName { get; set; }
        public string PlantTypePhoto { get; set; }
        public int WateringFrequency { get; set; }
        public int TransplantFrequency { get; set; }
        public string TemperatureRequirements { get; set; }
        public string SoilType { get; set; }
        public string PlantDescription { get; set; }
        public ICollection<Plant> Plants { get; set; }
    }
}
