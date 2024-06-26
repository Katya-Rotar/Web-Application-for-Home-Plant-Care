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
    }
}
