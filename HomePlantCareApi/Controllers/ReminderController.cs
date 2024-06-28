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

        [HttpGet("{id}")]
        public async Task<ActionResult<ReminderDto>> GetById(int id)
        {
            try
            {
                var reminderId = await this.reminderRepository.GetReminderById(id);
                if (reminderId == null)
                {
                    return NotFound();
                }
                else
                {
                    var plantIdDtos = reminderId.ConvertToReminderIdDto();
                    return Ok(plantIdDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddReminder(ReminderDto reminderDto)
        {
            try
            {
                var reminder = reminderDto.ConvertToNewReminder();
                await this.reminderRepository.AddReminder(reminder);

                var createdPlantDto = reminder.ConvertToReminderIdDto();

                return CreatedAtAction(nameof(GetById), new { id = reminder.ReminderID }, createdPlantDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReminder(int id, ReminderDto reminderDto)
        {
            try
            {
                var existingReminder = await this.reminderRepository.GetReminderById(id);
                
                existingReminder.ReminderID = reminderDto.ReminderID;
                existingReminder.PlantID = reminderDto.PlantID;
                existingReminder.ReminderDate = reminderDto.ReminderDate;
                existingReminder.ReminderType = reminderDto.ReminderType;
                existingReminder.IsCompleted = reminderDto.IsCompleted;

                await this.reminderRepository.UpdateReminder(existingReminder);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReminder(int id)
        {
            try
            {
                var reminder = await this.reminderRepository.GetReminderById(id);

                await this.reminderRepository.DeleteReminder(reminder);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
