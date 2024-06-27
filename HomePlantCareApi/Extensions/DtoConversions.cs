using HomePlantCareModels.Dtos;
using Web_Application_for_Home_Plant_Care.Models;

namespace HomePlantCareApi.Extensions
{
    public static class DtoConversions
    {
        public static PlantTypeDto ConvertToPlantTypeIdDto(this PlantType plantType) {
            return new PlantTypeDto
            {
                PlantTypeName = plantType.PlantTypeName,
                PlantTypePhoto = plantType.PlantTypePhoto,
                WateringFrequency = plantType.WateringFrequency,
                TransplantFrequency = plantType.TransplantFrequency,
                TemperatureRequirements = plantType.TemperatureRequirements,
                SoilType = plantType.SoilType,
                PlantDescription = plantType.PlantDescription,
            };
        }
        public static PlantDto ConvertToPlantIdDto(this Plant plant)
        {
            return new PlantDto
            {
                PlantID = plant.PlantID,
                PlantName = plant.PlantName,
                PlantTypeID = plant.PlantTypeID,
                PlantDescription = plant.PlantDescription,
                DateLastWatering = plant.DateLastWatering,
                DateLastTransplant = plant.DateLastTransplant,
            };
        }

        public static IEnumerable<PlantDto> ConvertToPlantDto(this IEnumerable<Plant> plants)
        {
            return plants.Select(plant => new PlantDto
            {
                PlantID = plant.PlantID,
                PlantName = plant.PlantName,
                PlantTypeID = plant.PlantTypeID,
                PlantDescription = plant.PlantDescription,
                DateLastWatering = plant.DateLastWatering,
                DateLastTransplant = plant.DateLastTransplant,
                PlantTypeName = plant.PlantType.PlantTypeName,
                PlantTypePhoto = plant.PlantType.PlantTypePhoto
            }).ToList();
        }
        public static IEnumerable<PlantTypeDto> ConvertToPlantTypeDto(this IEnumerable<PlantType> plantTypes) 
        {
            return plantTypes.Select(plantType => new PlantTypeDto 
            {
                PlantTypeID = plantType.PlantTypeID,
                PlantTypeName = plantType.PlantTypeName,
                PlantTypePhoto = plantType.PlantTypePhoto,
                WateringFrequency = plantType.WateringFrequency,
                TransplantFrequency = plantType.TransplantFrequency,
                TemperatureRequirements = plantType.TemperatureRequirements,
                SoilType = plantType.SoilType,
                PlantDescription = plantType.PlantDescription
            }).ToList();
        }
        public static IEnumerable<ReminderDto> ConvertToReminderDto(this IEnumerable<Reminder> reminders) {
            return reminders.Select(reminder => new ReminderDto
            {
                ReminderID = reminder.ReminderID,
                PlantID = reminder.PlantID,
                PlantName = reminder.Plant.PlantName,
                ReminderDate = reminder.ReminderDate,
                ReminderType = reminder.ReminderType,
                IsCompleted = reminder.IsCompleted
            }).ToList();
        }

        public static Plant ConvertToNewPlant(this CreatePlantDto plantDto) {
            return new Plant
            {
                PlantName = plantDto.PlantName,
                PlantTypeID = plantDto.PlantTypeID,
                PlantDescription = plantDto.PlantDescription,
                DateLastWatering = plantDto.DateLastWatering,
                DateLastTransplant = plantDto.DateLastTransplant,
            };
        }
    }
}
