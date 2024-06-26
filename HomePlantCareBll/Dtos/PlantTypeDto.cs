using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlantCareModels.Dtos
{
    public class PlantTypeDto
    {
        public int PlantTypeID { get; set; }
        public string PlantTypeName { get; set; }
        public string PlantTypePhoto { get; set; }
        public int WateringFrequency { get; set; }
        public int TransplantFrequency { get; set; }
        public string TemperatureRequirements { get; set; }
        public string SoilType { get; set; }
    }
}
