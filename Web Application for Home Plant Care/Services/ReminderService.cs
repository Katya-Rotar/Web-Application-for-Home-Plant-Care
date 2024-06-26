using HomePlantCareModels.Dtos;

using Web_Application_for_Home_Plant_Care.Services.Contracts;

namespace Web_Application_for_Home_Plant_Care.Services
{
    public class ReminderService : IReminderService
    {
        private readonly HttpClient httpClient;

        public ReminderService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ReminderDto>> GetReminders()
        {
            try
            {
                var reminders = await httpClient.GetFromJsonAsync<IEnumerable<ReminderDto>>("api/Reminder");
                return reminders;            
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
