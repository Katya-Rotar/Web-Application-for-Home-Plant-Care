using System.ComponentModel.DataAnnotations;

namespace HomePlantCareModels.Dtos
{
    public class CreatePlantDto
    {

        [Required(ErrorMessage = "Назва рослини обов'язкова")]
        public string PlantName { get; set; }

        [Required(ErrorMessage = "Тип рослини обов'язковий")]
        public int PlantTypeID { get; set; }
        public string PlantDescription { get; set; }

        [Required(ErrorMessage = "Дата останнього поливу обов'язкова")]
        public DateTime DateLastWatering { get; set; }

        [Required(ErrorMessage = "Дата останньої пересадки обов'язкова")]
        public DateTime DateLastTransplant { get; set; }
    }
}
