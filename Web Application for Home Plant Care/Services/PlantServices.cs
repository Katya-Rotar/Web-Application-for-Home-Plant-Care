using Microsoft.EntityFrameworkCore;
using Web_Application_for_Home_Plant_Care.Models;
using Web_Application_for_Home_Plant_Care.Services.Contracts;

namespace Web_Application_for_Home_Plant_Care.Services
{
    public class PlantServices : IPlantService
    {
        private readonly PlantDbContext plantDbContext;

        public PlantServices(PlantDbContext plantDbContext)
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
