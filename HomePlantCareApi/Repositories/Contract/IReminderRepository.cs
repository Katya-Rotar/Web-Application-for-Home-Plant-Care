using Web_Application_for_Home_Plant_Care.Models;

namespace HomePlantCareApi.Repositories.Contract
{
    public interface IReminderRepository
    {
        Task<IEnumerable<Reminder>> GetReminders();
        Task<Reminder> GetReminderById(int id);
        Task AddReminder(Reminder reminder);
        Task UpdateReminder(Reminder reminder);
        Task DeleteReminder(Reminder reminder);
    }
}
