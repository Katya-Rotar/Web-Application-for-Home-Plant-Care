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
            var today = DateTime.Today;
            var twoWeeksFromNow = today.AddDays(14);

            var reminders = await this.plantDbContext.Reminders
                                     .Include(p => p.Plant)
                                     .Where(r => r.ReminderDate <= twoWeeksFromNow )
                                     .OrderBy(r => r.ReminderDate)
                                     .ToListAsync();

            return reminders;
        }
    }
}
