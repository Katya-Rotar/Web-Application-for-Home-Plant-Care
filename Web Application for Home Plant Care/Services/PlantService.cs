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
                var response = await httpClient.PostAsJsonAsync("api/Plant", plantDto);
                response.EnsureSuccessStatusCode();
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
