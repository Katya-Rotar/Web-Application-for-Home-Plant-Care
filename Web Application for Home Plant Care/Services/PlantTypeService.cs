using HomePlantCareApi.Repositories.Contract;
using HomePlantCareModels.Dtos;
using Web_Application_for_Home_Plant_Care.Models;
using Web_Application_for_Home_Plant_Care.Services.Contracts;

namespace Web_Application_for_Home_Plant_Care.Services
{
    public class PlantTypeService : IPlantTypeService
    {
        private readonly HttpClient httpClient;

        public PlantTypeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<PlantTypeDto>> GetPlantTypes()
        {
            try
            {
                var plantTypes = await httpClient.GetFromJsonAsync<IEnumerable<PlantTypeDto>>("api/PlantType");
                return plantTypes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<PlantTypeDto> GetPlantTypeById(int id)
        {
            try
            {
                var plantsType = httpClient.GetFromJsonAsync<PlantTypeDto>($"api/PlantType/{id}");
                return plantsType;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
