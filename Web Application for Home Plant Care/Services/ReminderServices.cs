using Microsoft.EntityFrameworkCore;
using Web_Application_for_Home_Plant_Care.Models;

namespace Web_Application_for_Home_Plant_Care.Services
{
    public class ReminderServices
    {
        private readonly PlantDbContext _plantDbContext;

        public ReminderServices(PlantDbContext plantDbContext)
        {
            _plantDbContext = plantDbContext;
        }

        public async Task<IEnumerable<Reminder>> GetReminder()
        {
            var reminder = await _plantDbContext.Reminders
                                      .Include(p => p.Plant)
                                      .ToListAsync();
            return reminder;
        }
    }
}
