using HomePlantCareModels.Dtos;

namespace Web_Application_for_Home_Plant_Care.Services.Contracts
{
    public interface IReminderService
    {
        Task<IEnumerable<ReminderDto>> GetReminders();
    }
}
