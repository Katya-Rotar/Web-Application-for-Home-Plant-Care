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
        public async Task<Plant> GetPlantById(int id)
        {
            var plantId = await this.plantDbContext.Plants
                                          .Include(p => p.PlantType)
                                          .FirstOrDefaultAsync(p => p.PlantID == id);
            return plantId;
        }

        public async Task AddPlant(Plant plant)
        {
            await this.plantDbContext.Plants.AddAsync(plant);
            await this.plantDbContext.SaveChangesAsync();
        }


        public async Task UpdatePlant(Plant plant)
        {
            this.plantDbContext.Plants.Update(plant);
            await this.plantDbContext.SaveChangesAsync();
        }

        public async Task DeletePlant(Plant plant)
        {
            this.plantDbContext.Plants.Remove(plant);
            await this.plantDbContext.SaveChangesAsync();
        }
    }
}
