using HomePlantCareApi.Repositories.Contract;
using Microsoft.EntityFrameworkCore;
using Web_Application_for_Home_Plant_Care.Models;

namespace HomePlantCareApi.Repositories
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly PlantDbContext plantDbContext;
        public ReminderRepository(PlantDbContext plantDbContext)
        {
            this.plantDbContext = plantDbContext;
        }
        public async Task<IEnumerable<Reminder>> GetReminders()
        {
            var reminder = await this.plantDbContext.Reminders
                                      .Include(p => p.Plant)
                                      .ToListAsync();
            return reminder;
        }
    }
}
