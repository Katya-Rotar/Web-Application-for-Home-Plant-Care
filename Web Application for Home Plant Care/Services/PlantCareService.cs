using HomePlantCareApi.Repositories.Contract;
using HomePlantCareModels.Dtos;
using Web_Application_for_Home_Plant_Care.Models;
using Web_Application_for_Home_Plant_Care.Services.Contracts;

namespace Web_Application_for_Home_Plant_Care.Services
{
    public class PlantCareService : IPlantCareService
    {
        private readonly HttpClient httpClient;
        private readonly IPlantService plantService;
        private readonly IReminderService reminderService;

        public PlantCareService(HttpClient httpClient, IPlantService plantService, IReminderService reminderService)
        {
            this.httpClient = httpClient;
            this.plantService = plantService;
            this.reminderService = reminderService;
        }

        public async Task<IEnumerable<PlantCareDto>> GetPlantCares()
        {
            try
            {
                var plants = await httpClient.GetFromJsonAsync<IEnumerable<PlantCareDto>>("api/PlantCare");
                return plants;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<PlantCareDto> GetPlantCareById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddPlantCare(ReminderDto reminder)
        {
            try
            {
                var plantCareDto = new PlantCareDto
                {
                    PlantID = reminder.PlantID,
                    CareDate = DateTime.Today, // сьогоднішня дата
                    CareType = reminder.ReminderType
                };

                var response = await httpClient.PostAsJsonAsync("api/PlantCare", plantCareDto);
                response.EnsureSuccessStatusCode();

                // Отримання даних про рослину для отримання частот поливу
                var plantDto = await plantService.GetPlantById(reminder.PlantID);
                var plantType = await httpClient.GetFromJsonAsync<PlantTypeDto>($"api/PlantType/{plantDto.PlantTypeID}");

                // Видалення поточного нагадування
                await reminderService.DeleteReminder(reminder.ReminderID);

                // Створення нового нагадування з оновленою датою
                var newReminderDate = reminder.ReminderType == "Полив"
                    ? reminder.ReminderDate.AddDays(plantType.WateringFrequency)
                    : reminder.ReminderDate.AddDays(plantType.TransplantFrequency);

                await reminderService.AddReminder(new ReminderDto
                {
                    PlantID = reminder.PlantID,
                    ReminderDate = newReminderDate,
                    ReminderType = reminder.ReminderType
                });

                // Оновлення компоненту
                await reminderService.GetReminders();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddPlantCare: {ex.Message}");
                throw;
            }
        }

        public Task UpdatePlantCare(int id, PlantCareDto plantDto)
        {
            throw new NotImplementedException();
        }

        public Task DeletePlantCare(int id)
        {
            throw new NotImplementedException();
        }
    }
}
