using HomePlantCareModels.Dtos;

namespace Web_Application_for_Home_Plant_Care.Services.Contracts
{
    public interface IPlantService
    {
        Task<IEnumerable<PlantDto>> GetPlants();
        Task<PlantDto> GetPlantById(int id);
        Task AddPlant(CreatePlantDto plantDto);
        Task UpdatePlant(int id, CreatePlantDto plantDto);
        Task DeletePlant(int id);
        Task UpdateLastWateringDate(int plantID, DateTime today);
        Task UpdateLastTransplantDate(int plantID, DateTime today);
    }
}
