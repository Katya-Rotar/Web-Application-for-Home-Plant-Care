﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HomePlantCareModels.Dtos
{
    public class PlantDto
    {
        public int PlantID { get; set; }

        [Required(ErrorMessage = "Назва рослини обов'язкова")]
        public string PlantName { get; set; }

        [Required(ErrorMessage = "Тип рослини обов'язковий")]
        public int PlantTypeID { get; set; }

        [Required(ErrorMessage = "Тип рослини обов'язковий")]
        public string PlantDescription { get; set; }

        [Required(ErrorMessage = "Дата останнього поливу обов'язкова")]
        public DateTime DateLastWatering { get; set; }

        [Required(ErrorMessage = "Дата останньої пересадки обов'язкова")]
        public DateTime DateLastTransplant { get; set; }

        public string PlantTypeName { get; set; }
        public string PlantTypePhoto { get; set; }
    }
}
