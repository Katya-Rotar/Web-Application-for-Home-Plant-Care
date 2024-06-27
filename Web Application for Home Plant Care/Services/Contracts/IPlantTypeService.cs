using HomePlantCareModels.Dtos;

namespace Web_Application_for_Home_Plant_Care.Services.Contracts
{
    public interface IPlantTypeService
    {
        Task<IEnumerable<PlantTypeDto>> GetPlantTypes();
        Task<PlantTypeDto> GetPlantTypeById(int id);
    }
}
