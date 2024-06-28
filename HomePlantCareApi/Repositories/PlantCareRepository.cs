using HomePlantCareApi.Repositories.Contract;
using Microsoft.EntityFrameworkCore;
using Web_Application_for_Home_Plant_Care.Models;

namespace HomePlantCareApi.Repositories
{
    public class PlantCareRepository : IPlantCareRepository
    {
        private readonly PlantDbContext plantDbContext;

        public PlantCareRepository(PlantDbContext plantDbContext)
        {
            this.plantDbContext = plantDbContext;
        }
        public async Task<IEnumerable<PlantCare>> GetPlantsCare()
        {
            var plantCare = await this.plantDbContext.PlantCares
                                                     .Include(p => p.Plant)
                                                     .OrderByDescending(r => r.CareDate)
                                                     .ToListAsync();
            return plantCare;
        }
        public async Task<PlantCare> GetPlantCareById(int id)
        {
            var plantCare = await this.plantDbContext.PlantCares
                                                     .Include(p => p.Plant)
                                                     .FirstOrDefaultAsync(p => p.CareID == id);
            return plantCare;
        }
        public async Task AddPlantCare(PlantCare plant)
        {
            await this.plantDbContext.PlantCares.AddAsync(plant);
            await this.plantDbContext.SaveChangesAsync();
        }
        public async Task UpdatePlantCare(PlantCare plant)
        {
            this.plantDbContext.PlantCares.Update(plant);
            await this.plantDbContext.SaveChangesAsync();
        }
        public async Task DeletePlantCare(PlantCare plant)
        {
            this.plantDbContext.PlantCares.Remove(plant);
            await this.plantDbContext.SaveChangesAsync();
        }
    }
}
