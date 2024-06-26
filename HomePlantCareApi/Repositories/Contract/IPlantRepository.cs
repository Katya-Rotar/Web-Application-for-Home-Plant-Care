using Web_Application_for_Home_Plant_Care.Models;

namespace HomePlantCareApi.Repositories.Contract
{
    public interface IPlantRepository
    {
        Task<IEnumerable<Plant>> GetPlants();
    }
}
