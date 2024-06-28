using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlantCareModels.Dtos
{
    public class ReminderDto
    {
        public int ReminderID { get; set; }
        public int PlantID { get; set; }
        public DateTime ReminderDate { get; set; }
        public string ReminderType { get; set; }
        public bool IsCompleted { get; set; }
    }
}
