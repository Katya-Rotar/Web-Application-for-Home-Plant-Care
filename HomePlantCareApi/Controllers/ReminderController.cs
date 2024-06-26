using HomePlantCareApi.Extensions;
using HomePlantCareApi.Repositories.Contract;
using HomePlantCareModels.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomePlantCareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly IReminderRepository reminderRepository;

        public ReminderController(IReminderRepository reminderRepository)
        {
            this.reminderRepository = reminderRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReminderDto>>> GetReminder()
        {
            try
            {
                var reminders = await this.reminderRepository.GetReminders();
                if (reminders == null || !reminders.Any())
                {
                    return NotFound();
                }
                else 
                {
                    var reminderDtos = reminders.ConvertToReminderDto();
                    return Ok(reminderDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
