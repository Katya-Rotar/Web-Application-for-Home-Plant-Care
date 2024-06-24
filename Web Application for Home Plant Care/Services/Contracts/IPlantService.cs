
using Web_Application_for_Home_Plant_Care.Models;

namespace Web_Application_for_Home_Plant_Care.Services.Contracts
{
    public interface IPlantService
    {
        Task<IEnumerable<Plant>> GetPlants();
    }
}
