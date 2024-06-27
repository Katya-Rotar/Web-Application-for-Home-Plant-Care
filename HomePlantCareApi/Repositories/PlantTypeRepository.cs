using HomePlantCareApi.Repositories.Contract;
using Microsoft.EntityFrameworkCore;
using Web_Application_for_Home_Plant_Care.Models;

namespace HomePlantCareApi.Repositories
{
    public class PlantTypeRepository : IPlantTypeRepository
    {
        private readonly PlantDbContext plantDbContext;

        public PlantTypeRepository(PlantDbContext plantDbContext)
        {
            this.plantDbContext = plantDbContext;
        }
        public async Task<IEnumerable<PlantType>> GetPlantTypes()
        {
            return await this.plantDbContext.PlantTypes
                                             .Include(p => p.Plants)
                                             .ToListAsync();
        }
        public async Task<PlantType> GetPlantTypeById(int id)
        {
            var plantId = await this.plantDbContext.PlantTypes
                                          .Include(p => p.Plants)
                                          .FirstOrDefaultAsync(p => p.PlantTypeID == id);
            return plantId;
        }
    }
}
