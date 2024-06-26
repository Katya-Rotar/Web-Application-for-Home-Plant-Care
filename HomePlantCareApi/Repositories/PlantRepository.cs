using HomePlantCareApi.Repositories.Contract;
using Microsoft.EntityFrameworkCore;
using Web_Application_for_Home_Plant_Care.Models;

namespace HomePlantCareApi.Repositories
{
    public class PlantRepository : IPlantRepository
    {
        private readonly PlantDbContext plantDbContext;

        public PlantRepository(PlantDbContext plantDbContext)
        {
            this.plantDbContext = plantDbContext;
        }
        public async Task<IEnumerable<Plant>> GetPlants()
        {
            var plants = await this.plantDbContext.Plants
                                          .Include(p => p.PlantType)
                                          .ToListAsync();
            return plants;
        }
    }
}
