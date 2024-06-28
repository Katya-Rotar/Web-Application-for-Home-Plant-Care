
using HomePlantCareModels.Dtos;

namespace Web_Application_for_Home_Plant_Care.Services.Contracts
{
    public interface IPlantCareService
    {
        Task<IEnumerable<PlantCareDto>> GetPlantCares();
        Task<PlantCareDto> GetPlantCareById(int id);
        Task AddPlantCare(ReminderDto reminder);
        Task UpdatePlantCare(int id, PlantCareDto plantDto);
        Task DeletePlantCare(int id);
    }
}
