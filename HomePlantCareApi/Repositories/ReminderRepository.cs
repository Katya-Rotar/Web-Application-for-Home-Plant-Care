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
                                     
                                     .OrderBy(r => r.ReminderDate)
                                     .ToListAsync();

            return reminders;
        }
        public async Task<Reminder> GetReminderById(int id)
        {
            var reminder = await this.plantDbContext.Reminders
                                                .Include(p => p.Plant)
                                                .FirstOrDefaultAsync(p => p.ReminderID == id);
            return reminder;
        }

        public async Task AddReminder(Reminder reminder)
        {
            await this.plantDbContext.Reminders.AddAsync(reminder);
            await this.plantDbContext.SaveChangesAsync();
        }
        
        public async Task UpdateReminder(Reminder reminder)
        {
            this.plantDbContext.Reminders.Update(reminder);
            await this.plantDbContext.SaveChangesAsync();
        }

        public async Task DeleteReminder(Reminder reminder)
        {
            this.plantDbContext.Reminders.Remove(reminder);
            await this.plantDbContext.SaveChangesAsync();
        }
    }
}
