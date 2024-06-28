using Web_Application_for_Home_Plant_Care.Models;

namespace HomePlantCareApi.Repositories.Contract
{
    public interface IPlantCareRepository
    {
        Task<IEnumerable<PlantCare>> GetPlantsCare();
        Task<PlantCare> GetPlantCareById(int id);
        Task AddPlantCare(PlantCare plant);
        Task UpdatePlantCare(PlantCare plant);
        Task DeletePlantCare(PlantCare plant);
    }
}
