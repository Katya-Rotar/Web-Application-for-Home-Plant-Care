using HomePlantCareApi.Repositories.Contract;
using HomePlantCareModels.Dtos;
using Web_Application_for_Home_Plant_Care.Services.Contracts;

namespace Web_Application_for_Home_Plant_Care.Services
{
    public class PlantCareService : IPlantCareService
    {
        private readonly HttpClient httpClient;

        public PlantCareService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
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

        public Task AddPlantCare(PlantCareDto plantDto)
        {
            throw new NotImplementedException();
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
