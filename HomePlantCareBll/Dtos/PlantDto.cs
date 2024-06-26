using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlantCareModels.Dtos
{
    public class PlantDto
    {
        public int PlantID { get; set; }
        public string PlantName { get; set; }
        public int PlantTypeID { get; set; }
        public string PlantDescription { get; set; }
        public DateTime DateLastWatering { get; set; }
        public DateTime DateLastTransplant { get; set; }
        public string PlantTypeName { get; set; }
        public string PlantTypePhoto { get; set; } 
    }
}
