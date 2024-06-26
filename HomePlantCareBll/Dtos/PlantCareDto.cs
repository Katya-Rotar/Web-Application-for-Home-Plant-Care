using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlantCareModels.Dtos
{
    public class PlantCareDto
    {
        public int CareID { get; set; }
        public int PlantID { get; set; }
        public DateTime CareDate { get; set; }
        public string CareType { get; set; }
    }
}
