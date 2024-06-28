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
        public Task<ReminderDto> GetReminderById(int id)
        {
            try
            {
                var reminders = httpClient.GetFromJsonAsync<ReminderDto>($"api/Reminder/{id}");
                return reminders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task AddReminder(ReminderDto reminderDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("api/Reminder", reminderDto);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateReminder(int id, ReminderDto reminderDto)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync($"api/Reminder/{id}", reminderDto);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteReminder(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/Reminder/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
