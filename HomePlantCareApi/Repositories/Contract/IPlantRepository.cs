using Web_Application_for_Home_Plant_Care.Models;

namespace HomePlantCareApi.Repositories.Contract
{
    public interface IPlantRepository
    {
        Task<IEnumerable<Plant>> GetPlants();
        Task<Plant> GetPlantById(int id);
        Task AddPlant(Plant plant);
        Task UpdatePlant(Plant plant);
        Task DeletePlant(Plant plant);
    }
}
