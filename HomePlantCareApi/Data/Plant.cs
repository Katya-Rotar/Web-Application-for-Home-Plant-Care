using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_Application_for_Home_Plant_Care.Models
{
    public class Plant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
