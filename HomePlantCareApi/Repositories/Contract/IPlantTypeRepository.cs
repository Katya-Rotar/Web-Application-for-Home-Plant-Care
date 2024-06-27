using Web_Application_for_Home_Plant_Care.Models;

namespace HomePlantCareApi.Repositories.Contract
{
    public interface IPlantTypeRepository
    {
        Task<IEnumerable<PlantType>> GetPlantTypes();
        Task<PlantType> GetPlantTypeById(int id);
    }
}
