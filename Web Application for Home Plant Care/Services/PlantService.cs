using HomePlantCareModels.Dtos;
using Web_Application_for_Home_Plant_Care.Services.Contracts;

namespace Web_Application_for_Home_Plant_Care.Services
{
    public class PlantService : IPlantService
    {
        private readonly HttpClient httpClient;

        public PlantService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<PlantDto>> GetPlants()
        {
            try
            {
                var plants = await httpClient.GetFromJsonAsync<IEnumerable<PlantDto>>("api/Plant");
                return plants;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<PlantDto> GetPlantById(int id)
        {
            try
            {
                var plants = httpClient.GetFromJsonAsync<PlantDto>($"api/Plant/{id}");
                return plants;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddPlant(CreatePlantDto plantDto)
        {
            try
            {
                // Додати рослину
                var response = await httpClient.PostAsJsonAsync("api/Plant", plantDto);
                response.EnsureSuccessStatusCode();

                // Отримати тип рослини для отримання частот поливу та пересадки
                var plantType = await httpClient.GetFromJsonAsync<PlantTypeDto>($"api/PlantType/{plantDto.PlantTypeID}");

                // Створити нагадування про полив
                var wateringReminder = new ReminderDto
                {
                    PlantID = plantDto.PlantID,
                    ReminderDate = plantDto.DateLastWatering.AddDays(plantType.WateringFrequency),
                    ReminderType = "Watering"
                };
                await httpClient.PostAsJsonAsync("api/Reminder", wateringReminder);

                // Створити нагадування про пересадку
                var transplantReminder = new ReminderDto
                {
                    PlantID = plantDto.PlantID,
                    ReminderDate = plantDto.DateLastTransplant.AddDays(plantType.TransplantFrequency),
                    ReminderType = "Transplant"
                };
                await httpClient.PostAsJsonAsync("api/Reminder", transplantReminder);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task UpdatePlant(int id, CreatePlantDto plantDto)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync($"api/Plant/{id}", plantDto);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeletePlant(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/Plant/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
