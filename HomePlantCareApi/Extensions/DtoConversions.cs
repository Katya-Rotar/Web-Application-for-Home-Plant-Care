using HomePlantCareModels.Dtos;
using Web_Application_for_Home_Plant_Care.Models;

namespace HomePlantCareApi.Extensions
{
    public static class DtoConversions
    {
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
    }
}
